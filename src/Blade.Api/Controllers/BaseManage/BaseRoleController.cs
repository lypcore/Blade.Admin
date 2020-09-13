using Blade.IService.BaseManage;
using Blade.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Api.Controllers.BaseManage
{
    /// <summary>
    /// 应用密钥
    /// </summary>
    /// <seealso cref="Blade.Api.BaseApiController" />
    [Route("/BaseManage/[controller]/[action]")]
    public class BaseRoleController : BaseApiController
    {
        #region DI

        public BaseRoleController(IBaseRoleService roleBus)
        {
            _roleBus = roleBus;
        }

        IBaseRoleService _roleBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<BaseRoleInfoDTO>> GetDataList(PageInput<RolesInputDTO> input)
        {
            return await _roleBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<BaseRoleInfoDTO> GetTheData(IdInputDTO input)
        {
            return await _roleBus.GetTheDataAsync(input.id) ?? new BaseRoleInfoDTO();
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(BaseRoleInfoDTO input)
        {
            if (input.Id.IsNullOrEmpty())
            {
                InitEntity(input);

                await _roleBus.AddDataAsync(input);
            }
            else
            {
                await _roleBus.UpdateDataAsync(input);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _roleBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}