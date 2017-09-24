using Newtonsoft.Json;

namespace StreamElements.Net.Models
{
    public class Bot
    {

        [JsonProperty("_user")]
        public string User { get; set; }

        [JsonProperty("muted")]
        public bool Muted { get; set; }

        [JsonProperty("joined")]
        public bool Joined { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

    public class BotStats
    {

        [JsonProperty("commands")]
        public int Commands { get; set; }

        [JsonProperty("messages")]
        public int Messages { get; set; }

        [JsonProperty("timeouts")]
        public int Timeouts { get; set; }
    }

    public class BotObj
    {

        [JsonProperty("bot")]
        public Bot Bot { get; set; }

        [JsonProperty("stats")]
        public BotStats Stats { get; set; }
    }

}