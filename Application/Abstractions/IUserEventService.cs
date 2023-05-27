using Application.RequestApiModel;
using Domain.Shared;

namespace Application.Abstractions
{
    public interface IUserEventService
    {
        Task<Result> CreateUserEvent(UserEventRequestApiModel userEventRequest,
            CancellationToken cancellationToken);

        Task<Result> DeleteUserEvent(Guid id, CancellationToken cancellationToken);
    }
}
