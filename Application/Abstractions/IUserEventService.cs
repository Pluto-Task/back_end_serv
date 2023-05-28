using Application.RequestApiModel;
using Application.ResponseApiModel;
using Domain.Shared;

namespace Application.Abstractions
{
    public interface IUserEventService
    {
        Task<Result> CreateUserEvent(UserEventRequestApiModel userEventRequest,
            CancellationToken cancellationToken);

        Task<Result> DeleteUserEvent(Guid id, CancellationToken cancellationToken);

        Task<Result<UserEventsResponseApiModel>> GetAll(CancellationToken cancellationToken);

        Task<Result<UserEventResponseApiModel>> GetEvent(Guid id,CancellationToken cancellationToken);

        Task<Result<UserEventsResponseApiModel>> GetEventsByFilter(FilterRequestApiModel filter, CancellationToken cancellationToken);

        Task<Result<UserEventsResponseApiModel>> GetEventsCreatedByUser(CancellationToken cancellationToken);

        Task<Result<UserEventsResponseApiModel>> GetUserEvents( CancellationToken cancellationToken);

        Task<Result> BookEvent(Guid eventId, CancellationToken cancellationToken);
    }
}
