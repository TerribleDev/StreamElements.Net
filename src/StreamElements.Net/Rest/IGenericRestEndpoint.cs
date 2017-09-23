using System.Threading.Tasks;
using Refit;

namespace StreamElements.Net.Rest
{
    public interface IGenericRestEndpoint<T, in TKey> where T : class
    {
        [Get("")]
        Task<System.Collections.Generic.List<T>> GetAllAsync();

        [Get("/{key}")]
        Task<T> GetOneAsync(TKey key);
        
        [Post("")]
        Task<T> CreateAsync([Body] T paylod);

        [Put("/{key}")]
        Task<T> UpdateAsync(TKey key, [Body]T payload);

        [Delete("/{key}")]
        Task DeleteAsync(TKey key);
    }
}