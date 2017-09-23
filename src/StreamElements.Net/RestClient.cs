using System;
using System.Net.Http;
using Refit;
using StreamElements.Net.Rest;

namespace StreamElements.Net
{
    public class RestClient
    {
        public virtual T BuildHttpClient<T>(string pathSegment = null)
        {
            var builder = new UriBuilder("https://api.streamelements.com/kappa/v1");
            if(!string.IsNullOrEmpty(pathSegment)) builder.WithPathSegment(pathSegment);
            var httpClient = new HttpClient() { BaseAddress = builder.Uri };
            return RestService.For<T>(httpClient);
        }
    }
}