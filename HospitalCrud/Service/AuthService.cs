using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;
using HospitalCrud.Data;
using HospitalCrud.Service.interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HospitalCrud.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, AuthenticationStateProvider authenticationStateProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<IdentityResult> RealizarRegistro(string email, string senha, string role)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, senha);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            return result;
        }

        public async Task<ClaimsPrincipal> AuthenticateAsync(string userName, string password)
        {
            var user = await _userManager.FindByEmailAsync(userName);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                var claims = new List<Claim>
                {
                   new Claim(ClaimTypes.Email, userName)
                };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var identity = new ClaimsIdentity(claims, "custom");
                var principal = new ClaimsPrincipal(identity);

                return principal;
            }
            return null;
        }

        public async Task RealizarLogout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ClaimsPrincipal> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null)
                return new ClaimsPrincipal();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                // Adicione outras claims personalizadas aqui, se necessário
            };

            return new ClaimsPrincipal(new ClaimsIdentity(claims, "custom"));
        }

    }
}
