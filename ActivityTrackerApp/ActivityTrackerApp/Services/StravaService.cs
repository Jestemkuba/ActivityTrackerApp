using ActivityTrackerApp.Client;
using ActivityTrackerApp.Exceptions;
using ActivityTrackerApp.Models.DTOs;
using ActivityTrackerApp.Services.Contracts;
using System.Threading.Tasks;

namespace ActivityTrackerApp.Services
{
    class StravaService : IStravaService
    {
        private readonly StravaClient _stravaClient;

        public StravaService(StravaClient stravaClient)
        {
            _stravaClient = stravaClient;
        }

        public async Task<StravaAccessTokenResponseDto> GetStravaAccessToken(string code)
        {
            try
            {
                var stravaAccessTokenResponse = await _stravaClient.GetStravaAccessToken("63072", "563a513fe062b03fa26ad2e9814a5d906826b3be", code, "authorization_code");
                return stravaAccessTokenResponse;
            }
            catch (FetchingTokenFailedException)
            {
                throw;
            }
        }
    }
}
