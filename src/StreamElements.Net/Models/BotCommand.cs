using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StreamElements.Net.Models
{
   public class Cooldown
    {

        [JsonProperty("global")]
        public int Global { get; set; }

        [JsonProperty("user")]
        public int User { get; set; }
    }

    public class BotCommand
    {

        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("reply")]
        public string Reply { get; set; }

        [JsonProperty("accessLevel")]
        public BotActionEnum AccessLevel { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("cost")]
        public int Cost { get; set; }

        [JsonProperty("cooldown")]
        public Cooldown Cooldown { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("aliases")]
        public IList<string> Aliases { get; set; }
    }
}