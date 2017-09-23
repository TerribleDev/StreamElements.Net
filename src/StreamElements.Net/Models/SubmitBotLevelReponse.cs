using System;
using Newtonsoft.Json;

namespace StreamElements.Net.Models
{
    // public class SubmitBotLevel
    // {
    //     public string username { get; set; }
    //     public BotLevelEnum level { get; set; }
    // }
    public class SubmitBotLevelResponse
    {

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("lastActive")]
        public DateTime LastActive { get; set; }

        [JsonProperty("moderator")]
        public bool Moderator { get; set; }

        [JsonProperty("subscriber")]
        public bool Subscriber { get; set; }

        [JsonProperty("level")]
        public BotLevelEnum Level { get; set; }
    }
}