using System;
using Newtonsoft.Json;

namespace StreamElements.Net.Models.Results
{
    public class BotCommandResult : BotCommand, IStreamElementsResult
    {
        [JsonProperty("updatedAt")]
        System.DateTime IStreamElementsResult.UpdatedAt { get; set; }

        [JsonProperty("createdAt")]
        System.DateTime IStreamElementsResult.CreatedAt { get; set; }

        [JsonProperty("_user")]
        string IStreamElementsResult.User { get; set; }

        [JsonProperty("_username")]
        string IStreamElementsResult.Username { get; set; }
    }
}