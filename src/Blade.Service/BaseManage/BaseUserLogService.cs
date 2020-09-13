using Blade.Entity.BaseManage;
using Blade.IService.BaseManage;
using Blade.Util;
using EFCore.Sharding;
using LinqKit;
using System.Linq;
using System.Threading.Tasks;

namespace Blade.Service.BaseManage
{
    public class BaseUserLogService : BaseService<BaseUserLog>, IBaseUserLogService, ITransientDependency
    {
        public BaseUserLogService(IDbAccessor db)
            : base(db)
        {
        }

        public async Task<PageResult<BaseUserLog>> GetLogListAsync(PageInput<UserLogsInputDTO> input)
        {
            var whereExp = LinqHelper.True<BaseUserLog>();
            var search = input.Search;
            if (!search.logContent.IsNullOrEmpty())
                whereExp = whereExp.And(x => x.LogContent.Contains(search.logContent));
            if (!search.logType.IsNullOrEmpty())
                whereExp = whereExp.And(x => x.LogType == search.logType);
            if (!search.opUserName.IsNullOrEmpty())
                whereExp = whereExp.And(x => x.CreatorRealName.Contains(search.opUserName));
            if (!search.startTime.IsNullOrEmpty())
                whereExp = whereExp.And(x => x.CreateTime >= search.startTime);
            if (!search.endTime.IsNullOrEmpty())
                whereExp = whereExp.And(x => x.CreateTime <= search.endTime);

            return await GetIQueryable().Where(whereExp).GetPageResultAsync(input);
        }
    }
}