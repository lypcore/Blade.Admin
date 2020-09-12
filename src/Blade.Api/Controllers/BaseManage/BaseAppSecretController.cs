using Blade.Service.BaseManage;
using Blade.Entity.BaseManage;
using Blade.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Api.Controllers.BaseManage
{
    /// <summary>
    /// 应用密钥
    /// </summary>
    /// <seealso cref="Blade.Api.BaseApiController" />
    [Route("/BaseManage/[controller]/[action]")]
    public class BaseAppSecretController : BaseApiController
    {
        #region DI

        public BaseAppSecretController(IBaseAppSecretService appSecretBus)
        {
            _appSecretBus = appSecretBus;
        }

        IBaseAppSecretService _appSecretBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<BaseAppSecret>> GetDataList(PageInput<AppSecretsInputDTO> input)
        {
            return await _appSecretBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<BaseAppSecret> GetTheData(IdInputDTO input)
        {
            return await _appSecretBus.GetTheDataAsync(input.id) ?? new BaseAppSecret();
        }

        #endregion

        #region 提交

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="theData">保存的数据</param>
        [HttpPost]
        public async Task SaveData(BaseAppSecret theData)
        {
            if (theData.Id.IsNullOrEmpty())
            {
                InitEntity(theData);

                await _appSecretBus.AddDataAsync(theData);
            }
            else
            {
                await _appSecretBus.UpdateDataAsync(theData);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ids">id数组,JSON数组</param>
        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _appSecretBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}