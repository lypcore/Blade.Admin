using Blade.IService.BaseManage;
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
    public class BaseDbLinkController : BaseApiController
    {
        #region DI

        public BaseDbLinkController(IBaseDbLinkService dbLinkBus)
        {
            _dbLinkBus = dbLinkBus;
        }

        IBaseDbLinkService _dbLinkBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<AjaxResult<List<BaseDbLink>>> GetDataList(PageInput input)
        {
            return await _dbLinkBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<BaseDbLink> GetTheData(IdInputDTO input)
        {
            return await _dbLinkBus.GetTheDataAsync(input.id) ?? new BaseDbLink();
        }

        #endregion

        #region 提交

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="theData">保存的数据</param>
        [HttpPost]
        public async Task SaveData(BaseDbLink theData)
        {
            if (theData.Id.IsNullOrEmpty())
            {
                InitEntity(theData);

                await _dbLinkBus.AddDataAsync(theData);
            }
            else
            {
                await _dbLinkBus.UpdateDataAsync(theData);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ids">id数组,JSON数组</param>
        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _dbLinkBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}