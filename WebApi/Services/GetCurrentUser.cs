using System;
using System.Security.Claims;
using Application.Interface;

namespace WebApi.Services
{
    public class GetCurrentUser : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetCurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string getCurrentUser()
        {
            throw new NotImplementedException();
            // return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}