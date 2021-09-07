using ActivityTrackerApp.Models.DTOs;
using Refit;
using System;

using System.Threading.Tasks;

namespace ActivityTrackerApp.Client.Contracts
{
    interface IStravaApi
    {
        [Post("/oauth/token")]
        Task<StravaAccessTokenResponseDto> GetStravaAccessToken([AliasAs("client_id")] string clientId,
            [AliasAs("client_secret")] string clientSecret,
            string code,
            [AliasAs("grant_type")] string grantType);
    }
}
