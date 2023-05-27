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
    }
}
