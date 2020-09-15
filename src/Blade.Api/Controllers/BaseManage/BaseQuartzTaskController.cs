using Blade.Service.BaseManage;
using Blade.Entity.BaseManage;
using Blade.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Api.Controllers.BaseManage
{
    [Route("/BaseManage/[controller]/[action]")]
    public class BaseQuartzTaskController : BaseApiController
    {
        #region DI

        public BaseQuartzTaskController(IBaseQuartzTaskService baseQuartzTaskBus)
        {
            _baseQuartzTaskBus = baseQuartzTaskBus;
        }

        IBaseQuartzTaskService _baseQuartzTaskBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<BaseQuartzTask>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _baseQuartzTaskBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<BaseQuartzTask> GetTheData(IdInputDTO input)
        {
            return await _baseQuartzTaskBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(BaseQuartzTask data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _baseQuartzTaskBus.AddDataAsync(data);
            }
            else
            {
                await _baseQuartzTaskBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _baseQuartzTaskBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}