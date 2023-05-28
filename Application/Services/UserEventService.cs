using Application.Abstractions;
using Application.RequestApiModel;
using Application.ResponseApiModel;
using Domain.Entity;
using Domain.Enums;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Services
{
    public class UserEventService : IUserEventService
    {
        private readonly IGenericRepository<UserEvent> _userEventRepository;
        private readonly IGenericRepository<EventSkills> _eventSkillsRepository;
        private readonly IGenericRepository<UserEventTable> _userEventTableRepository;
        private readonly IUserAccessor _userAccessor;
        private readonly IUnitOfWork _unitOfWork;
        public UserEventService(IGenericRepository<UserEvent> userEventRepository, IGenericRepository<EventSkills> eventSkillsRepository, IUserAccessor userAccessor, IUnitOfWork unitOfWork,
            IGenericRepository<UserEventTable> userEventTableRepository)
        {
            _userEventTableRepository =userEventTableRepository;
            _userEventRepository = userEventRepository;
            _userAccessor = userAccessor;
            _unitOfWork = unitOfWork;
            _eventSkillsRepository = eventSkillsRepository;
        }
        public async Task<Result> CreateUserEvent(UserEventRequestApiModel userEventRequest, CancellationToken cancellationToken)
        {
            var userEvent = new UserEvent(userEventRequest.Title, userEventRequest.Description, userEventRequest.StartDate, userEventRequest.EndDate,
                userEventRequest.MaxPeople,
                userEventRequest.CurrentPeople,
                userEventRequest.Address, userEventRequest.Build, userEventRequest.PhoneNumber,
                userEventRequest.Coordinates, userEventRequest.Email,
                _userAccessor.GetCurrentUserId());
            await _userEventRepository.CreateAsync(userEvent, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            foreach (var skill in userEventRequest.Skills)
            {
                await _eventSkillsRepository.CreateAsync(new EventSkills(){UserEventId = userEvent.Id, SkillId = skill.SkillId, Exp = skill.Exp}, cancellationToken);
            }

            await _userEventTableRepository.CreateAsync(new UserEventTable()
                { IsConfirmed = false, UserEventId = userEvent.Id, UserId = _userAccessor.GetCurrentUserId() },cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        public async Task<Result> DeleteUserEvent(Guid id, CancellationToken cancellationToken)
        {
            var userEventFromDb = await _userEventRepository.FindByIdAsync(id, cancellationToken);

            if (userEventFromDb == null)
            {
                return Result.Failure(DomainErrors.User.InvalidId);//change
            }

            var skills = await _eventSkillsRepository.GetAllByFilterAsync(x => x.UserEventId == id,cancellationToken);

            foreach (var skill in skills)
            {
                _eventSkillsRepository.Delete(skill);
            }

            _userEventRepository.Delete(userEventFromDb);


            var userEventTable =
                await _userEventTableRepository.GetAllByFilterAsync(x => x.UserEventId == userEventFromDb.Id,cancellationToken);

            foreach (var userEvent in userEventTable)
            {
                _userEventTableRepository.Delete(userEvent);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        public async Task<Result<UserEventsResponseApiModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _userEventRepository.GetWithInclude(x => true, cancellationToken,y=>y.EventSkills);

            var newResult = new UserEventsResponseApiModel(result.Select(x => new UserEventResponseApiModel(x.Id,
                x.Title, x.Description, x.StartDate, x.EndDate,
                x.EventSkills
                    .Select(y => new EventSkillsResponseApiModel(Enum.GetName(typeof(SkillName), y.SkillId), y.Exp)),
                x.PhoneNumber, x.Email, x.Address, x.Build, x.Coordinates)));

            return newResult;
        }

        public async Task<Result<UserEventResponseApiModel>> GetEvent(Guid id,CancellationToken cancellationToken)
        {
            var result = await _userEventRepository.GetWithInclude(x=> x.Id == id,cancellationToken,y=>y.EventSkills);
            var userEvent = result.FirstOrDefault();

            var userEventMapped = new UserEventResponseApiModel(userEvent.Id, userEvent.Title, userEvent.Description,
                userEvent.StartDate, userEvent.EndDate, userEvent.EventSkills
                    .Select(y => new EventSkillsResponseApiModel(Enum.GetName(typeof(SkillName), y.SkillId), y.Exp)),
                userEvent.PhoneNumber, userEvent.Email, userEvent.Address, userEvent.Build, userEvent.Coordinates);

            return userEventMapped;
        }

        public async Task<Result<UserEventsResponseApiModel>> GetEventsByFilter(FilterRequestApiModel filter, CancellationToken cancellationToken)
        {
            var result = await _userEventRepository.GetWithInclude(x=>true, cancellationToken, y => y.EventSkills);
            result = result.Where(x => x.Address == filter.City || x.MaxPeople ==filter.MaxPeople || x.EventSkills.Any(y => filter.Skills.Contains(y.SkillId)));

            var newResult = new UserEventsResponseApiModel(result.Select(x => new UserEventResponseApiModel(x.Id,
                x.Title, x.Description, x.StartDate, x.EndDate,
                x.EventSkills
                    .Select(y => new EventSkillsResponseApiModel(Enum.GetName(typeof(SkillName), y.SkillId), y.Exp)),
                x.PhoneNumber, x.Email, x.Address, x.Build, x.Coordinates)));

            return newResult;
        }
    }
}
