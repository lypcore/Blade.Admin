using Blade.Entity.BaseManage;
using Blade.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Service.BaseManage
{
    public interface IBaseDbLinkService
    {
        Task<PageResult<BaseDbLink>> GetDataListAsync(PageInput input);
        Task<BaseDbLink> GetTheDataAsync(string id);
        Task AddDataAsync(BaseDbLink newData);
        Task UpdateDataAsync(BaseDbLink theData);
        Task DeleteDataAsync(List<string> ids);
    }
}