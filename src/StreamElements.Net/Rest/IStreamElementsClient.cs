using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace StreamElements.Net.Rest
{
    public interface IStreamElementsApi
    {
         [Get("/chatstats/search/{channel}")]
         Task<List<string>> SearchChannels (string channel);

         [Get("/chatstats/stats/{channel}")]
         Task<Models.ChatStats> GetChatStats(string channel);
         
         [Get("/loyalties/{channel}")]
         Task<StreamElements.Net.Models.Results.LoyaltyResult> GetLoyalties(string channel);
    }
}