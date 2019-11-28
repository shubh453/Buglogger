using Buglogger.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Buglogger.Api.Services
{
    public class CurrentUserService : ICurrentUser
    {
        public string UserId { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}