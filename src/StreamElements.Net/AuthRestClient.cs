using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using StreamElements.Net.Models;
using StreamElements.Net.Models.Results;
using StreamElements.Net.Rest;

namespace StreamElements.Net
{

    public class AuthRestClient : RestClient
    {
        private string JwtToken { get; }
        private IAuthenticatedStreamElementsApi AuthClient { get; }
        private IGenericRestEndpoint<BotCommand, BotCommandResult, string> BotCommandClient { get; }
        private IGenericRestEndpoint<BotTimer, BotTimerResult, string> BotTimerClient { get; }
        
        public AuthRestClient(string jwtToken)
        {
            this.JwtToken = jwtToken;
            if (string.IsNullOrWhiteSpace(jwtToken))
            {
                throw new ArgumentNullException(nameof(jwtToken));
            }
            this.AuthClient = BuildHttpClient<IAuthenticatedStreamElementsApi>();
            BotCommandClient = BuildHttpClient<IGenericRestEndpoint<BotCommand, BotCommandResult, string>>("bot/commands");
            BotTimerClient = BuildHttpClient<IGenericRestEndpoint<BotTimer, BotTimerResult,  string>>("bot/timers");
        }
        /// <summary>
        /// Returns a list of activities sorted by createdAt.
        /// </summary>
        /// <returns></returns>
        public Task<IList<Activity>> GetActivities() => AuthClient.GetActivitiesAsync();
       
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
            return AuthClient.GetActivityAsync(id);
        }
        /// <summary>
        /// Returns an object with information about the bot.
        /// </summary>
        /// <returns></returns>
        public Task<BotObj> GetBotAsync() => AuthClient.GetBotAsync();
        /// <summary>
        /// Returns the bots action log. These logs include command updates.
        /// </summary>
        /// <returns></returns>
        public Task<List<BotLog>> GetBotLogsAsync() => AuthClient.GetBotLogsAsync();
        /// <summary>
        /// Make the bot do something
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Task<Result> PostBotActionAsync(BotActionEnum action)
        {
            var actionParsed = Enum.GetName(typeof(BotActionEnum), action);
            return this.AuthClient.PostBotActionAsync(actionParsed);
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
            return AuthClient.PostBotSayAsync(new{ message } );
        }
        /// <summary>
        /// Returns an array of users with levels in your channel.
        /// </summary>
        /// <returns></returns>
        public Task<BotLevels> GetBotLevels() => AuthClient.GetBotLevelsAsync();
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
            return AuthClient.PostBotLevelAsync(new { username = userName, level = botEnum});
        }

        public Task<List<BotCommandResult>> GetBotCommandsAsync() => BotCommandClient.GetAllAsync();

        public Task<BotCommandResult> GetBotCommandAsync(string id)
        {
            if(string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            return BotCommandClient.GetOneAsync(id);
        }

        public Task<BotCommandResult> PostBotCommand(BotCommand command)
        {
            if(command == null) throw new ArgumentNullException(nameof(command));
            return BotCommandClient.CreateAsync(command);
        }

        public Task<BotCommandResult> PutBotCommand (string id, BotCommand command)
        {
            if(string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            if(command == null) throw new ArgumentNullException(nameof(command));
            return BotCommandClient.UpdateAsync(id, command);
        }
        public Task DeleteBotCommand(string id)
        {
            if(string.IsNullOrWhiteSpace(id)) 
            {
                throw new ArgumentNullException(nameof(id));
            }
            return BotCommandClient.DeleteAsync(id);
        }
        /// <summary>
        /// Returns an array of timers
        /// </summary>
        /// <returns></returns>
        public Task<List<BotTimerResult>> GetBotTimers() => this.BotTimerClient.GetAllAsync();

        /// <summary>
        /// Returns a single timer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<BotTimerResult> GetBotTimer(string id)
        {
            if(string.IsNullOrWhiteSpace(id)) 
            {
                throw new ArgumentNullException(nameof(id));
            }
            return this.BotTimerClient.GetOneAsync(id);
        }
        /// <summary>
        /// Update a single timer
        /// </summary>
        /// <returns></returns>
        public Task<BotTimerResult> UpdateBotTimer(string id, BotTimer timer)
        {
            if(string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            if(timer == null)
            {
                throw new ArgumentNullException(nameof(timer));
            }
            return this.BotTimerClient.UpdateAsync(id, timer);
        }

        public Task<BotTimerResult> CreateBotTimer(BotTimer timer)
        {
            if(timer == null)
            {
                throw new ArgumentNullException(nameof(timer));
            }
            return this.BotTimerClient.CreateAsync(timer);
        }

        public Task DeleteBotTimer(string id)
        {
            if(string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return BotTimerClient.DeleteAsync(id);
        }

        public Task<ChatStatsSettingsResult> GetChatStats => this.AuthClient.GetChatStatsSettings();

        public Task<ChatStatsSettingsResult> UpdateChatStats(ChatStatistics statsistics)
        {
            if(statsistics == null)
            {
                throw new ArgumentNullException(nameof(statsistics));
            }
            return this.AuthClient.UpdateChatStatsSettings(statsistics);
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