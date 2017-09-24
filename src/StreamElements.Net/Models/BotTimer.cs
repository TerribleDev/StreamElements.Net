using Newtonsoft.Json;

namespace StreamElements.Net.Models
{
        public class Offline
    {

        [JsonProperty("interval")]
        public int Interval { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

    public class Online
    {

        [JsonProperty("interval")]
        public int Interval { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

    public class BotTimer
    {



        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("chatLines")]
        public int ChatLines { get; set; }

        [JsonProperty("offline")]
        public Offline Offline { get; set; }

        [JsonProperty("online")]
        public Online Online { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

}