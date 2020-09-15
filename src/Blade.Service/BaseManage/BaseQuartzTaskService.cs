using Blade.Entity.BaseManage;
using Blade.Util;
using Blade.Util.Helper;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Blade.Service.BaseManage
{
    public class BaseQuartzTaskService : BaseService<BaseQuartzTask>, IBaseQuartzTaskService, ITransientDependency
    {
        public BaseQuartzTaskService(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<BaseQuartzTask>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<BaseQuartzTask>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<BaseQuartzTask, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<BaseQuartzTask> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(BaseQuartzTask data)
        {
            
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(BaseQuartzTask data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        #endregion

        #region 私有成员

        #endregion
    }
}