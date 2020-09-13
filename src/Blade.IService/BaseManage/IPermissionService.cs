using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.IService.BaseManage
{
    public interface IPermissionService
    {
        Task<List<string>> GetUserPermissionValuesAsync(string userId);
        Task<List<BaseActionDTO>> GetUserMenuListAsync(string userId);
    }
}
