using System;
using Newtonsoft.Json;

namespace StreamElements.Net.Models
{
       public class Data
    {

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class Activity
    {

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("_username")]
        public string Username { get; set; }

        /// <summary>
        /// could be one of the following strings: follow, host, tip, subscriber, cheer
        /// </summary>
        /// <returns></returns>
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
    }

}