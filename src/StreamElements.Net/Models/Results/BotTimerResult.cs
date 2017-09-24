using Newtonsoft.Json;

namespace StreamElements.Net.Models.Results
{
    public class BotTimerResult : BotTimer, IStreamElementsResult
    {
        [JsonProperty("updatedAt")]
        public System.DateTime UpdatedAt { get; set; }

        [JsonProperty("createdAt")]
        public System.DateTime CreatedAt { get; set; }

        [JsonProperty("_user")]
        public string User { get; set; }

        [JsonProperty("_username")]
        public string Username { get; set; }
    }
}