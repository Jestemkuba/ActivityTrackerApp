using System.Text.Json.Serialization;

namespace ActivityTrackerApp.Models.DTOs
{
    public class StravaAccessTokenResponseDto
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}
