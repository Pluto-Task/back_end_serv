using Application.Abstractions;
using Application.RequestApiModel;
using Domain.Entity;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Services
{
    public class UserEventService : IUserEventService
    {
        private readonly IGenericRepository<UserEvent> _userEventRepository;
        private readonly IGenericRepository<EventSkills> _eventSkillsRepository;

        private readonly IUserAccessor _userAccessor;
        private readonly IUnitOfWork _unitOfWork;
        public UserEventService(IGenericRepository<UserEvent> userEventRepository, IGenericRepository<EventSkills> eventSkillsRepository, IUserAccessor userAccessor, IUnitOfWork unitOfWork)
        {
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


            foreach(var skill in userEventRequest.Skills)
            {
                await _eventSkillsRepository.CreateAsync(new EventSkills(){UserEventId = userEvent.Id, SkillId = skill.SkillId, Exp = skill.Exp}, cancellationToken);
            }

            
            await _userEventRepository.CreateAsync(userEvent, cancellationToken);
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

            return Result.Success();
        }
    }
}
