using Blade.Entity;
using Blade.Entity.BaseManage;
using Blade.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.IService.BaseManage
{
    public interface IBaseRoleService
    {
        Task<PageResult<BaseRoleInfoDTO>> GetDataListAsync(PageInput<RolesInputDTO> input);
        Task<BaseRoleInfoDTO> GetTheDataAsync(string id);
        Task AddDataAsync(BaseRoleInfoDTO input);
        Task UpdateDataAsync(BaseRoleInfoDTO input);
        Task DeleteDataAsync(List<string> ids);
    }

    public class RolesInputDTO
    {
        public string roleId { get; set; }
        public string roleName { get; set; }
    }

    [Map(typeof(BaseRole))]
    public class BaseRoleInfoDTO : BaseRole
    {
        public RoleTypes? RoleType { get => RoleName?.ToEnum<RoleTypes>(); }
        public List<string> Actions { get; set; } = new List<string>();
    }
}