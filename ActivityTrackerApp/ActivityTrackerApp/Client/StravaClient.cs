using ActivityTrackerApp.Client.Contracts;
using ActivityTrackerApp.Exceptions;
using ActivityTrackerApp.Models.DTOs;
using Refit;
using System;
using System.Threading.Tasks;

namespace ActivityTrackerApp.Client
{
    class StravaClient
    {
        private readonly IStravaApi _stravaApi;

        public StravaClient()
        {
            var stravaApi = RestService.For<IStravaApi>("https://www.strava.com/");
            _stravaApi = stravaApi;
        }

        public async Task<StravaAccessTokenResponseDto> GetStravaAccessToken(string clientId, string clientSecret, string code, string grantType)
        {
            try
            {
                var result = await _stravaApi.GetStravaAccessToken(clientId, clientSecret, code, grantType);
                return result;
            }
            catch (ApiException)
            {
                throw new FetchingTokenFailedException();
            }
        }
    }
}
