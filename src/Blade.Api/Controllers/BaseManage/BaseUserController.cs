using Blade.IService.BaseManage;
using Blade.Entity;
using Blade.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Api.Controllers.BaseManage
{
    [Route("/BaseManage/[controller]/[action]")]
    public class BaseUserController : BaseApiController
    {
        #region DI

        public BaseUserController(IBaseUserService userBus)
        {
            _userBus = userBus;
        }

        IBaseUserService _userBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<BaseUserDTO>> GetDataList(PageInput<BaseUsersInputDTO> input)
        {
            return await _userBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<BaseUserDTO> GetTheData(IdInputDTO input)
        {
            return await _userBus.GetTheDataAsync(input.id) ?? new BaseUserDTO();
        }

        [HttpPost]
        public async Task<List<SelectOption>> GetOptionList(OptionListInputDTO input)
        {
            return await _userBus.GetOptionListAsync(input);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(UserEditInputDTO input)
        {
            if (!input.newPwd.IsNullOrEmpty())
                input.Password = input.newPwd.ToMD5String();
            if (input.Id.IsNullOrEmpty())
            {
                InitEntity(input);

                await _userBus.AddDataAsync(input);
            }
            else
            {
                await _userBus.UpdateDataAsync(input);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _userBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}