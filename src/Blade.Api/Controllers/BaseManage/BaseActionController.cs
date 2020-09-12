using Blade.Service.BaseManage;
using Blade.Entity;
using Blade.Entity.BaseManage;
using Blade.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Api.Controllers.BaseManage
{
    /// <summary>
    /// 系统权限
    /// </summary>
    /// <seealso cref="Blade.Api.BaseApiController" />
    [Route("/BaseManage/[controller]/[action]")]
    public class BaseActionController : BaseApiController
    {
        #region DI

        public BaseActionController(IBaseActionService actionBus)
        {
            _actionBus = actionBus;
        }

        IBaseActionService _actionBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<BaseAction> GetTheData(IdInputDTO input)
        {
            return (await _actionBus.GetTheDataAsync(input.id)) ?? new BaseAction();
        }

        [HttpPost]
        public async Task<List<BaseAction>> GetPermissionList(BaseActionsInputDTO input)
        {
            input.types = new ActionType[] { Entity.ActionType.权限 };

            return await _actionBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<List<BaseAction>> GetAllActionList()
        {
            return await _actionBus.GetDataListAsync(new BaseActionsInputDTO
            {
                types = new ActionType[] { ActionType.菜单, ActionType.页面, ActionType.权限 }
            });
        }

        [HttpPost]
        public async Task<List<BaseActionDTO>> GetMenuTreeList(BaseActionsInputDTO input)
        {
            input.selectable = true;
            input.types = new ActionType[] { ActionType.菜单, ActionType.页面 };

            return await _actionBus.GetTreeDataListAsync(input);
        }

        [HttpPost]
        public async Task<List<BaseActionDTO>> GetActionTreeList(BaseActionsInputDTO input)
        {
            input.selectable = false;

            return await _actionBus.GetTreeDataListAsync(input);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(ActionEditInputDTO input)
        {
            if (input.Id.IsNullOrEmpty())
            {
                InitEntity(input);

                await _actionBus.AddDataAsync(input);
            }
            else
            {
                await _actionBus.UpdateDataAsync(input);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _actionBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}