using Blade.Entity.BaseManage;
using Blade.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.IService.BaseManage
{
    public interface IBaseReadLibraryService
    {
        Task<List<BaseReadLibrary>> GetAllDataListAsync();
        Task<PageResult<BaseReadLibrary>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<BaseReadLibrary> GetTheDataAsync(string id);
        Task AddDataAsync(BaseReadLibrary data);
        Task UpdateDataAsync(BaseReadLibrary data);
        Task DeleteDataAsync(List<string> ids);
    }
}