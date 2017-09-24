using Newtonsoft.Json;

namespace StreamElements.Net.Models
{
    public class ChatStatsSettings
    {
        [JsonProperty("stats")]
        public ChatStatistics Stats { get; set; }

        [JsonProperty("twitchchat")]
        public bool Twitchchat { get; set; }

        [JsonProperty("ignored_chatters")]
        public string IgnoredChatters { get; set; }

        [JsonProperty("messages_per_second")]
        public bool MessagesPerSecond { get; set; }

        [JsonProperty("total_messages")]
        public bool TotalMessages { get; set; }

        [JsonProperty("emoteflow")]
        public bool Emoteflow { get; set; }
    }
    public class ChatStatistics
    {

        [JsonProperty("commands")]
        public int Commands { get; set; }

        [JsonProperty("hashtags")]
        public int Hashtags { get; set; }

        [JsonProperty("bttv")]
        public int Bttv { get; set; }

        [JsonProperty("twitch")]
        public int Twitch { get; set; }

        [JsonProperty("top_chatters")]
        public int TopChatters { get; set; }
    }
}