using Blade.Entity;
using Blade.Util;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Blade.Service.BaseManage;

namespace Blade.Service.Cache
{
    class BaseUserCache : BaseCache<BaseUserDTO>, IBaseUserCache, ITransientDependency
    {
        readonly IServiceProvider _serviceProvider;
        public BaseUserCache(IServiceProvider serviceProvider, IDistributedCache cache)
            : base(cache)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task<BaseUserDTO> GetDbDataAsync(string key)
        {
            PageInput<BaseUsersInputDTO> input = new PageInput<BaseUsersInputDTO>
            {
                Search = new BaseUsersInputDTO
                {
                    all = true,
                    userId = key
                }
            };
            var list = await _serviceProvider.GetService<IBaseUserService>().GetDataListAsync(input);

            return list.Data.FirstOrDefault();
        }
    }
}
