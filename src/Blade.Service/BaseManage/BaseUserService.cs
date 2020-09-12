using AutoMapper;
using Blade.Service.Cache;
using Blade.Entity;
using Blade.IService;
using Blade.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blade.Entity.BaseManage;
using Blade.Service.BaseManage;
using Coldairarrow.Util;

namespace Blade.Service.Service
{
    public class BaseUserService : BaseService<BaseUser>, IBaseUserService, ITransientDependency
    {
        readonly IOperator _operator;
        readonly IMapper _mapper;
        public BaseUserService(
            IDbAccessor db,
            IBaseUserCache userCache,
            IOperator @operator,
            IMapper mapper
            )
            : base(db)
        {
            _userCache = userCache;
            _operator = @operator;
            _mapper = mapper;
        }
        IBaseUserCache _userCache { get; }
        protected override string _textField => "RealName";

        #region 外部接口

        public async Task<PageResult<BaseUserDTO>> GetDataListAsync(PageInput<BaseUsersInputDTO> input)
        {
            Expression<Func<BaseUser, BaseDepartment, BaseUserDTO>> select = (a, b) => new BaseUserDTO
            {
                DepartmentName = b.Name
            };
            var search = input.Search;
            select = select.BuildExtendSelectExpre();
            var q_User = search.all ? Db.GetIQueryable<BaseUser>() : GetIQueryable();
            var q = from a in q_User.AsExpandable()
                    join b in Db.GetIQueryable<BaseDepartment>() on a.DepartmentId equals b.Id into ab
                    from b in ab.DefaultIfEmpty()
                    select @select.Invoke(a, b);

            q = q.WhereIf(!search.userId.IsNullOrEmpty(), x => x.Id == search.userId);
            if (!search.keyword.IsNullOrEmpty())
            {
                var keyword = $"%{search.keyword}%";
                q = q.Where(x =>
                      EF.Functions.Like(x.UserName, keyword)
                      || EF.Functions.Like(x.RealName, keyword));
            }

            var list = await q.GetPageResultAsync(input);

            await SetProperty(list.Data);

            return list;

            async Task SetProperty(List<BaseUserDTO> users)
            {
                //补充用户角色属性
                List<string> userIds = users.Select(x => x.Id).ToList();
                var userRoles = await (from a in Db.GetIQueryable<BaseUserRole>()
                                       join b in Db.GetIQueryable<BaseRole>() on a.RoleId equals b.Id
                                       where userIds.Contains(a.UserId)
                                       select new
                                       {
                                           a.UserId,
                                           RoleId = b.Id,
                                           b.RoleName
                                       }).ToListAsync();
                users.ForEach(aUser =>
                {
                    var roleList = userRoles.Where(x => x.UserId == aUser.Id);
                    aUser.RoleIdList = roleList.Select(x => x.RoleId).ToList();
                    aUser.RoleNameList = roleList.Select(x => x.RoleName).ToList();
                });
            }
        }

        public async Task<BaseUserDTO> GetTheDataAsync(string id)
        {
            if (id.IsNullOrEmpty())
                return null;
            else
            {
                PageInput<BaseUsersInputDTO> input = new PageInput<BaseUsersInputDTO>
                {
                    Search = new BaseUsersInputDTO
                    {
                        all = true,
                        userId = id
                    }
                };
                return (await GetDataListAsync(input)).Data.FirstOrDefault();
            }
        }

        [DataAddLog(UserLogType.系统用户管理, "RealName", "用户")]
        [DataRepeatValidate(
            new string[] { "UserName" },
            new string[] { "用户名" })]
        [Transactional]
        public async Task AddDataAsync(UserEditInputDTO input)
        {
            await InsertAsync(_mapper.Map<BaseUser>(input));
            await SetUserRoleAsync(input.Id, input.RoleIdList);
        }

        [DataEditLog(UserLogType.系统用户管理, "RealName", "用户")]
        [DataRepeatValidate(
            new string[] { "UserName" },
            new string[] { "用户名" })]
        [Transactional]
        public async Task UpdateDataAsync(UserEditInputDTO input)
        {
            if (input.Id == GlobalData.ADMINID && _operator?.UserId != input.Id)
                throw new BusException("禁止更改超级管理员！");

            await UpdateAsync(_mapper.Map<BaseUser>(input));
            await SetUserRoleAsync(input.Id, input.RoleIdList);
            await _userCache.UpdateCacheAsync(input.Id);
        }

        [DataDeleteLog(UserLogType.系统用户管理, "RealName", "用户")]
        [Transactional]
        public async Task DeleteDataAsync(List<string> ids)
        {
            if (ids.Contains(GlobalData.ADMINID))
                throw new BusException("超级管理员是内置账号,禁止删除！");

            await DeleteAsync(ids);

            await _userCache.UpdateCacheAsync(ids);
        }

        #endregion

        #region 私有成员

        private async Task SetUserRoleAsync(string userId, List<string> roleIds)
        {
            roleIds = roleIds ?? new List<string>();
            var userRoleList = roleIds.Select(x => new BaseUserRole
            {
                Id = IdHelper.GetId(),
                CreateTime = DateTime.Now,
                UserId = userId,
                RoleId = x
            }).ToList();
            await Db.DeleteAsync<BaseUserRole>(x => x.UserId == userId);
            await Db.InsertAsync(userRoleList);
        }

        #endregion
    }
}