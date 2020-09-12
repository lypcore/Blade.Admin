using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Service.Cache
{
    public interface IBaseCache<T> where T : class
    {
        Task<T> GetCacheAsync(string idKey);
        Task UpdateCacheAsync(string idKey);
        Task UpdateCacheAsync(List<string> idKeys);
    }
}