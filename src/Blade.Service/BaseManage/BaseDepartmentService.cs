using Blade.Entity.BaseManage;
using Blade.Service.BaseManage;
using Blade.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blade.Service.Service
{
    public class BaseDepartmentService : BaseService<BaseDepartment>, IBaseDepartmentService, ITransientDependency
    {
        public BaseDepartmentService(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<List<BaseDepartmentTreeDTO>> GetTreeDataListAsync(DepartmentsTreeInputDTO input)
        {
            var where = LinqHelper.True<BaseDepartment>();
            if (!input.parentId.IsNullOrEmpty())
                where = where.And(x => x.ParentId == input.parentId);

            var list = await GetIQueryable().Where(where).ToListAsync();
            var treeList = list
                .Select(x => new BaseDepartmentTreeDTO
                {
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Text = x.Name,
                    Value = x.Id
                }).ToList();

            return TreeHelper.BuildTree(treeList);
        }

        public async Task<List<string>> GetChildrenIdsAsync(string departmentId)
        {
            var allNode = await GetIQueryable().Select(x => new TreeModel
            {
                Id = x.Id,
                ParentId = x.ParentId,
                Text = x.Name,
                Value = x.Id
            }).ToListAsync();

            var children = TreeHelper
                .GetChildren(allNode, allNode.Where(x => x.Id == departmentId).FirstOrDefault(), true)
                .Select(x => x.Id)
                .ToList();

            return children;
        }

        public async Task<BaseDepartment> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        [DataRepeatValidate(new string[] { "Name" }, new string[] { "部门名" })]
        [DataAddLog(UserLogType.部门管理, "Name", "部门名")]
        public async Task AddDataAsync(BaseDepartment newData)
        {
            await InsertAsync(newData);
        }

        [DataRepeatValidate(new string[] { "Name" }, new string[] { "部门名" })]
        [DataEditLog(UserLogType.部门管理, "Name", "部门名")]
        public async Task UpdateDataAsync(BaseDepartment theData)
        {
            await UpdateAsync(theData);
        }

        [DataDeleteLog(UserLogType.部门管理, "Name", "部门名")]
        public async Task DeleteDataAsync(List<string> ids)
        {
            if (await GetIQueryable().AnyAsync(x => ids.Contains(x.ParentId)))
                throw new BusException("禁止删除！请先删除所有子级！");

            await DeleteAsync(ids);
        }

        #endregion
    }
}