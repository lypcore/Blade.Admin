using Blade.Entity.BaseManage;
using Blade.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Service.BaseManage
{
    public interface IBaseQuartzTaskService
    {
        Task<PageResult<BaseQuartzTask>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<BaseQuartzTask> GetTheDataAsync(string id);
        Task AddDataAsync(BaseQuartzTask data);
        Task UpdateDataAsync(BaseQuartzTask data);
        Task DeleteDataAsync(List<string> ids);
    }
}