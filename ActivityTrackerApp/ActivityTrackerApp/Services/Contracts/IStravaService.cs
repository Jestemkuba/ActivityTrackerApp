using ActivityTrackerApp.Models.DTOs;
using System.Threading.Tasks;

namespace ActivityTrackerApp.Services.Contracts
{
    public interface IStravaService
    {
        Task<StravaAccessTokenResponseDto> GetStravaAccessToken(string code);
    }
}
