using System.Security.Claims;
using System.Threading.Tasks;
using HospitalCrud.Service.interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace HospitalCrud.Service
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomAuthenticationStateProvider(IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await _authService.GetCurrentUser();

            if (user != null)
            {
                var identity = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Email, user.Identity.Name),
        }, "custom");

                var principal = new ClaimsPrincipal(identity);

                return new AuthenticationState(principal);
            }
            else
            {
                return new AuthenticationState(new ClaimsPrincipal());
            }
        }


        public async Task MarkUserAsAuthenticated(string email)
        {
            var user = await _authService.GetCurrentUser();

            if (user.Identity.IsAuthenticated)
            {
                var identity = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, user.Identity.Name),
        }, "custom");

                var principal = new ClaimsPrincipal(identity);

                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
            }
        }

    }
}
