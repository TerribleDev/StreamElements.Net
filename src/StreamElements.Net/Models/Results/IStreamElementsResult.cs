using Newtonsoft.Json;

namespace StreamElements.Net.Models.Results
{
    public interface IStreamElementsResult
    {
        [JsonProperty("updatedAt")]
        System.DateTime UpdatedAt { get; set; }

        [JsonProperty("createdAt")]
        System.DateTime CreatedAt { get; set; }

        [JsonProperty("_user")]
        string User { get; set; }

        [JsonProperty("_username")]
        string Username { get; set; }
    }
}