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
        private readonly IUserAccessor _userAccessor;
        private readonly IUnitOfWork _unitOfWork;
        public UserEventService(IGenericRepository<UserEvent> userEventRepository, IUserAccessor userAccessor, IUnitOfWork unitOfWork)
        {
            _userEventRepository = userEventRepository;
            _userAccessor = userAccessor;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> CreateUserEvent(UserEventRequestApiModel userEventRequest, CancellationToken cancellationToken)
        {
            var userEvent = new UserEvent(userEventRequest.Title, userEventRequest.StartDate, userEventRequest.EndDate,
                userEventRequest.Skills,
                userEventRequest.Address, userEventRequest.Build, userEventRequest.PhoneNumber,
                userEventRequest.Coordinates, userEventRequest.Email,
                _userAccessor.GetCurrentUserId());

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

            _userEventRepository.Delete(userEventFromDb);

            return Result.Success();
        }
    }
}
