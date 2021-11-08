using EssenceRealty.Data.Identity.Models;
using EssenceRealty.Domain.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EssenceRealty.Data.Identity.Contract
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task<bool> ResetPassword(ResetPasswordRequest request);
        Task<bool> ForgotPassword(ForgotPasswordRequest request);
        Task<bool> ChangePassword(ChangePasswordRequest request, ClaimsPrincipal user);
    }
}
