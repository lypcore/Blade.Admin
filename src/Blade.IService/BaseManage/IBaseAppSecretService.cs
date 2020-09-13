using Blade.Entity.BaseManage;
using Blade.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.IService.BaseManage
{
    public interface IBaseAppSecretService
    {
        Task<PageResult<BaseAppSecret>> GetDataListAsync(PageInput<AppSecretsInputDTO> input);
        Task<BaseAppSecret> GetTheDataAsync(string id);
        Task<string> GetAppSecretAsync(string appId);
        Task AddDataAsync(BaseAppSecret newData);
        Task UpdateDataAsync(BaseAppSecret theData);
        Task DeleteDataAsync(List<string> ids);
    }

    public class AppSecretsInputDTO
    {
        public string keyword { get; set; }
    }
}