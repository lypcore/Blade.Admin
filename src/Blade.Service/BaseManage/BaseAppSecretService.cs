﻿using Blade.Entity.BaseManage;
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
    public class BaseAppSecretService : BaseService<BaseAppSecret>, IBaseAppSecretService, ITransientDependency
    {
        public BaseAppSecretService(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<BaseAppSecret>> GetDataListAsync(PageInput<AppSecretsInputDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<BaseAppSecret>();
            var search = input.Search;
            if (!search.keyword.IsNullOrEmpty())
            {
                where = where.And(x =>
                    x.AppId.Contains(search.keyword)
                    || x.AppSecret.Contains(search.keyword)
                    || x.AppName.Contains(search.keyword));
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<BaseAppSecret> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task<string> GetAppSecretAsync(string appId)
        {
            var theData = await GetIQueryable().Where(x => x.AppId == appId).FirstOrDefaultAsync();

            return theData?.AppSecret;
        }

        [DataRepeatValidate(new string[] { "AppId" },
            new string[] { "应用Id" })]
        [DataAddLog(UserLogType.接口密钥管理, "AppId", "应用Id")]
        public async Task AddDataAsync(BaseAppSecret newData)
        {
            await InsertAsync(newData);
        }

        [DataRepeatValidate(new string[] { "AppId" },
            new string[] { "应用Id" })]
        [DataEditLog(UserLogType.接口密钥管理, "AppId", "应用Id")]
        public async Task UpdateDataAsync(BaseAppSecret theData)
        {
            await UpdateAsync(theData);
        }

        [DataDeleteLog(UserLogType.接口密钥管理, "AppId", "应用Id")]
        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        #endregion

        #region 私有成员

        #endregion
    }
}