using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using StreamElements.Net.Models;
using StreamElements.Net.Rest;

namespace StreamElements.Net
{
    public class RestClient
    {
        private IStreamElementsApi Client { get; }
        public RestClient()
        {
            this.Client = BuildHttpClient<IStreamElementsApi>();
        }

        public Task<List<string>> SearchChannels(string channel)
        {
            if(string.IsNullOrWhiteSpace(channel))
            {
                throw new ArgumentNullException(nameof(channel));
            }
            return Client.SearchChannels(channel);
        }
        public Task<ChatStats> GetChatStats(string channel)
        {
            if(string.IsNullOrWhiteSpace(channel))
            {
                throw new ArgumentNullException(channel);
            }
            return Client.GetChatStats(channel);
        }
        public Task<Models.Results.LoyaltyResult> GetLoyalty(string channel)
        {
            if(string.IsNullOrWhiteSpace(nameof(channel)))
            {
                throw new ArgumentNullException(nameof(channel));
            }
            return this.Client.GetLoyalties(channel);
        }
        public virtual T BuildHttpClient<T>(string pathSegment = null)
        {
            var builder = new UriBuilder("https://api.streamelements.com/kappa/v1");
            if(!string.IsNullOrEmpty(pathSegment)) builder.WithPathSegment(pathSegment);
            var httpClient = new HttpClient() { BaseAddress = builder.Uri };
            return RestService.For<T>(httpClient);
        }
    }
}