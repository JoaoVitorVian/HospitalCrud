using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HospitalCrud.Service.interfaces
{
    public interface IAuthService
    {
        Task<ClaimsPrincipal> AuthenticateAsync(string userName, string password);

        Task<IdentityResult> RealizarRegistro(string email, string senha, string role);

        Task RealizarLogout();

        Task<ClaimsPrincipal> GetCurrentUser();

    }
}
