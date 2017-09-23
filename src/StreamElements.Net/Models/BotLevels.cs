using Newtonsoft.Json;

namespace StreamElements.Net.Models
{
    public class BotLevels
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("lastActive")]
        public string LastActive { get; set; }

        [JsonProperty("moderator")]
        public bool Moderator { get; set; }

        [JsonProperty("subscriber")]
        public bool Subscriber { get; set; }

        [JsonProperty("level")]
        public BotLevelEnum Level { get; set; }
    }
}