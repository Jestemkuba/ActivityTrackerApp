using ActivityTrackerApp.Models.DTOs;
using System.Threading.Tasks;

namespace ActivityTrackerApp.Services
{
    public interface IAuthService
    {
        public Task Register(RegisterRequestDto registerRequestDto);
        public Task<string> Login(LoginRequestDto loginRequestDto);
    }
}
