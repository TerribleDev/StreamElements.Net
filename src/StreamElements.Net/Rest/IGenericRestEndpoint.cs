using System.Threading.Tasks;
using Refit;

namespace StreamElements.Net.Rest
{
    public interface IGenericRestEndpoint<T, TResult, in TKey> 
    where T : class
    where TResult : class
    {
        [Get("")]
        Task<System.Collections.Generic.List<TResult>> GetAllAsync();

        [Get("/{key}")]
        Task<TResult> GetOneAsync(TKey key);
        
        [Post("")]
        Task<TResult> CreateAsync([Body] T paylod);

        [Put("/{key}")]
        Task<TResult> UpdateAsync(TKey key, [Body]T payload);

        [Delete("/{key}")]
        Task DeleteAsync(TKey key);
    }
}