using Newtonsoft.Json;

namespace StreamElements.Net.Models
{
    public class Bonuses
    {

        [JsonProperty("cheer")]
        public int Cheer { get; set; }

        [JsonProperty("subscriber")]
        public int Subscriber { get; set; }

        [JsonProperty("tip")]
        public int Tip { get; set; }

        [JsonProperty("follow")]
        public int Follow { get; set; }
    }

    public class Loyalty
    {

        [JsonProperty("bonuses")]
        public Bonuses Bonuses { get; set; }

        [JsonProperty("subscriberMultiplier")]
        public int SubscriberMultiplier { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}