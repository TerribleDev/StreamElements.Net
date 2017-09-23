using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using StreamElements.Net.Models;

namespace StreamElements.Net.Rest
{
    public interface IAuthenticatedStreamElementsApi
    {
        [Get("/activities")]
         Task<IList<Activity>> GetActivitiesAsync();

         [Get("/activities/{id}")]
         Task<Activity> GetActivityAsync(string id);
         
         [Get("/bot")]
         Task<BotObj> GetBotAsync();
         
         [Get("/bot/logs")]
         Task<List<BotLog>> GetBotLogsAsync();

         [Post("/bot/{action}")]
         Task<Result> PostBotActionAsync(string action);

         [Post("/bot/say")]
         Task<Result> PostBotSayAsync([Body] object message);
         
         [Get("/bot/levels")]
         Task<BotLevels> GetBotLevels();

         [Post("/bot/levels")]
         Task<SubmitBotLevelResponse> PostBotLevel([Body] object submit);
    }
}