using Application.Abstractions;
using Application.RequestApiModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstractions;

namespace Presentation.Controllers
{
    [Authorize]
    [Route("/api/userEvent/")]
    public class UserEventController : ApiController
    {
        private readonly IUserEventService _userEventService;

        public UserEventController(IUserEventService userEventService)
        {
            _userEventService = userEventService;
        }



        [HttpPost("createEvent")]
        public async Task<IActionResult> CreateUserEvent([FromBody] UserEventRequestApiModel request,
            CancellationToken cancellationToken)
        {
            var result = await _userEventService.CreateUserEvent(request, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok();
        }

        [HttpDelete("deleteEvent/{id}")]
        public async Task<IActionResult> DeleteUserEvent(Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _userEventService.DeleteUserEvent(id, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await _userEventService.GetAll(token);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id,CancellationToken cancellationToken)
        {
            var result = await _userEventService.GetEvent(id,cancellationToken);
            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpPost("getByFilter")]
        public async Task<IActionResult> GetByFilter([FromBody]FilterRequestApiModel request,CancellationToken cancellationToken)
        {
            var result = await _userEventService.GetEventsByFilter(request,cancellationToken);
            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("getCreatedByUser")]
        public async Task<IActionResult> GetCreatedByUser(CancellationToken cancellationToken)
        {
            var result = await _userEventService.GetEventsCreatedByUser(cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("getUserEvents")]
        public async Task<IActionResult> GetUserEvents(CancellationToken cancellationToken)
        {
            var result = await _userEventService.GetUserEvents(cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("book/{id}")]
        public async Task<IActionResult> BookEvent(Guid id, CancellationToken cancellationToken)
        {
            var result = await _userEventService.BookEvent(id,cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok();
        }
    }
}
