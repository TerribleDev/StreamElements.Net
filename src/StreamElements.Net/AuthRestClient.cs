using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using StreamElements.Net.Models;
using StreamElements.Net.Rest;

namespace StreamElements.Net
{

    public class AuthRestClient : RestClient
    {
        private string JwtToken { get; }
        private IAuthenticatedStreamElementsApi Client { get; }
        private IGenericRestEndpoint<BotCommand,string> BotCommandClient { get; }
        public AuthRestClient(string jwtToken)
        {
            this.JwtToken = jwtToken;
            if (string.IsNullOrWhiteSpace(jwtToken))
            {
                throw new ArgumentNullException(nameof(jwtToken));
            }
            this.Client = BuildHttpClient<IAuthenticatedStreamElementsApi>();
            BotCommandClient = BuildHttpClient<IGenericRestEndpoint<BotCommand, string>>("bot/commands");
        }
        /// <summary>
        /// Returns a list of activities sorted by createdAt.
        /// </summary>
        /// <returns></returns>
        public Task<IList<Activity>> GetActivities() => Client.GetActivitiesAsync();
       
        /// <summary>
        /// Returns a single activity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Activity> GetActivity(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return Client.GetActivityAsync(id);
        }
        /// <summary>
        /// Returns an object with information about the bot.
        /// </summary>
        /// <returns></returns>
        public Task<BotObj> GetBotAsync() => Client.GetBotAsync();
        /// <summary>
        /// Returns the bots action log. These logs include command updates.
        /// </summary>
        /// <returns></returns>
        public Task<List<BotLog>> GetBotLogsAsync() => Client.GetBotLogsAsync();
        /// <summary>
        /// Make the bot do something
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Task<Result> PostBotActionAsync(BotActionEnum action)
        {
            var actionParsed = Enum.GetName(typeof(BotActionEnum), action);
            return this.Client.PostBotActionAsync(actionParsed);
        }
        /// <summary>
        /// Makes the bot send a message in current user's the channel.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task<Result> PostBotSayAsync(string message)
        {
            if(string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }
            return Client.PostBotSayAsync(new{ message } );
        }
        /// <summary>
        /// Returns an array of users with levels in your channel.
        /// </summary>
        /// <returns></returns>
        public Task<BotLevels> GetBotLevels() => Client.GetBotLevelsAsync();
        /// <summary>
        /// Create a new permission for the current channel.
        /// </summary>
        /// <returns></returns>
        public Task<SubmitBotLevelResponse> PostBotLevels(string userName, BotLevelEnum botEnum)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }
            return Client.PostBotLevelAsync(new { username = userName, level = botEnum});
        }

        public Task<List<BotCommand>> GetBotCommandsAsync() => BotCommandClient.GetAllAsync();

        public Task<BotCommand> GetBotCommandAsync(string id)
        {
            if(string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            return BotCommandClient.GetOneAsync(id);
        }

        public Task<BotCommand> PostBotCommand(BotCommand command)
        {
            if(command == null) throw new ArgumentNullException(nameof(command));
            return BotCommandClient.CreateAsync(command);
        }

        public Task<BotCommand> PutBotCommand (string id, BotCommand command)
        {
            if(string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            if(command == null) throw new ArgumentNullException(nameof(command));
            return BotCommandClient.UpdateAsync(id, command);
        }
        public Task DeleteCommand(string id)
        {
            if(string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            return BotCommandClient.DeleteAsync(id);
        }
        public override T BuildHttpClient<T>(string pathSegment = null)
        {
            var builder = new UriBuilder("https://api.streamelements.com/kappa/v1");
            if(!string.IsNullOrEmpty(pathSegment)) builder.WithPathSegment(pathSegment);
            var httpClient = new HttpClient() { BaseAddress = builder.Uri };
            httpClient.DefaultRequestHeaders.Add("authorization", $"Bearer {this.JwtToken}");
            return RestService.For<T>(httpClient);
        }
    }
}