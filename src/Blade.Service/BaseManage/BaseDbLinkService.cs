using Blade.Entity.BaseManage;
using Blade.IService.BaseManage;
using Blade.Util;
using EFCore.Sharding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Service.BaseManage
{
    public class BaseDbLinkService : BaseService<BaseDbLink>, IBaseDbLinkService, ITransientDependency
    {
        public BaseDbLinkService(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<BaseDbLink>> GetDataListAsync(PageInput input)
        {
            return await GetIQueryable().GetPageResultAsync(input);
        }

        public async Task<BaseDbLink> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(BaseDbLink newData)
        {
            await InsertAsync(newData);
        }

        public async Task UpdateDataAsync(BaseDbLink theData)
        {
            await UpdateAsync(theData);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        #endregion

        #region 私有成员

        #endregion

        #region 数据模型

        #endregion
    }
}