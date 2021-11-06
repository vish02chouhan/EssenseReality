using EssenceRealty.Data.Identity.Models;
using System.Threading.Tasks;

namespace EssenceRealty.Data.Identity.Contract
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
