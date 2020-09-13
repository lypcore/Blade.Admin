using Blade.Entity;
using Blade.Entity.BaseManage;
using Blade.IService.BaseManage;
using Blade.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blade.Service.BaseManage
{
    class PermissionService : BaseService<BaseAction>, IPermissionService, ITransientDependency
    {
        public PermissionService(IDbAccessor db, IBaseActionService actionBus, IBaseUserService userBus)
            : base(db)
        {
            _actionBus = actionBus;
            _userBus = userBus;
        }
        IBaseActionService _actionBus { get; }
        IBaseUserService _userBus { get; }

        async Task<string[]> GetUserActionIds(string userId)
        {
            var where = LinqHelper.False<BaseAction>();
            var theUser = await _userBus.GetTheDataAsync(userId);

            //不需要权限的菜单
            where = where.Or(x => x.NeedAction == false);

            if (userId == GlobalData.ADMINID || theUser.RoleType.HasFlag(RoleTypes.超级管理员))
                where = where.Or(x => true);
            else
            {
                var actionIds = from a in Db.GetIQueryable<BaseUserRole>()
                                join b in Db.GetIQueryable<BaseRoleAction>() on a.RoleId equals b.RoleId
                                where a.UserId == userId
                                select b.ActionId;

                where = where.Or(x => actionIds.Contains(x.Id));
            }

            return await GetIQueryable().Where(where).Select(x => x.Id).ToArrayAsync();
        }

        public async Task<List<BaseActionDTO>> GetUserMenuListAsync(string userId)
        {
            var actionIds = await GetUserActionIds(userId);
            return await _actionBus.GetTreeDataListAsync(new BaseActionsInputDTO
            {
                types = new ActionType[] { ActionType.菜单, ActionType.页面 },
                ActionIds = actionIds,
                checkEmptyChildren = true
            });
        }

        public async Task<List<string>> GetUserPermissionValuesAsync(string userId)
        {
            var actionIds = await GetUserActionIds(userId);
            return (await _actionBus
                .GetDataListAsync(new BaseActionsInputDTO
                {
                    types = new ActionType[] { ActionType.权限 },
                    ActionIds = actionIds
                }))
                .Select(x => x.Value)
                .ToList();
        }
    }
}
