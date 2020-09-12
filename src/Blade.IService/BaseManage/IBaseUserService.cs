using Blade.Entity;
using Blade.Entity.BaseManage;
using Blade.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Service.BaseManage
{
    public interface IBaseUserService
    {
        Task<PageResult<BaseUserDTO>> GetDataListAsync(PageInput<BaseUsersInputDTO> input);
        Task<List<SelectOption>> GetOptionListAsync(OptionListInputDTO input);
        Task<BaseUserDTO> GetTheDataAsync(string id);
        Task AddDataAsync(UserEditInputDTO input);
        Task UpdateDataAsync(UserEditInputDTO input);
        Task DeleteDataAsync(List<string> ids);
    }

    [Map(typeof(BaseUser))]
    public class UserEditInputDTO : BaseUser
    {
        public string newPwd { get; set; }
        public List<string> RoleIdList { get; set; }
    }

    public class BaseUsersInputDTO
    {
        public bool all { get; set; }
        public string userId { get; set; }
        public string keyword { get; set; }
    }
}