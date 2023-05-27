using Application.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Authentication;

public class UserAccessor : IUserAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserAccessor()
    {
        _httpContextAccessor = new HttpContextAccessor();
    }

    public Guid GetCurrentUserId()
    {
        var id = Guid.Parse(_httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        return id;
    }
}