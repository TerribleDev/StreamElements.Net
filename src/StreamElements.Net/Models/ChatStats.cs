using System.Collections.Generic;
using Newtonsoft.Json;

namespace StreamElements.Net.Models
{
    public class Chatter
    {

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }

    public class Chatlines
    {

        [JsonProperty("chatters")]
        public IList<Chatter> Chatters { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }
    }

    public class Twitch
    {

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Bttv
    {

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Emotes
    {

        [JsonProperty("twitch")]
        public IList<Twitch> Twitch { get; set; }

        [JsonProperty("bttv")]
        public IList<Bttv> Bttv { get; set; }
    }

    public class Command
    {

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }

    public class ChatStats
    {

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("chatlines")]
        public Chatlines Chatlines { get; set; }

        [JsonProperty("emotes")]
        public Emotes Emotes { get; set; }

        [JsonProperty("commands")]
        public IList<Command> Commands { get; set; }

        [JsonProperty("hashtags")]
        public IList<object> Hashtags { get; set; }
    }
}