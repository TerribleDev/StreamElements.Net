using System;
using System.Net.Http;
using Refit;
using StreamElements.Net.Rest;

namespace StreamElements.Net
{
    public class RestClient
    {
        public virtual T BuildHttpClient<T>()
        {
            var httpClient = new HttpClient() { BaseAddress = new Uri("https://api.streamelements.com/kappa/v1") };
            return RestService.For<T>(httpClient);
        }
    }
}