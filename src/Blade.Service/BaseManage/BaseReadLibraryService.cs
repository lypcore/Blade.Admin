using Blade.Entity.BaseManage;
using Blade.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Blade.Service.BaseManage
{
    public class BaseReadLibraryService : BaseService<BaseReadLibrary>, IBaseReadLibraryService, ITransientDependency
    {
        public BaseReadLibraryService(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<BaseReadLibrary>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<BaseReadLibrary>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<BaseReadLibrary, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<BaseReadLibrary> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(BaseReadLibrary data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(BaseReadLibrary data)
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