using Blade.IService.BaseManage;
using Blade.Entity.BaseManage;
using Blade.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Api.Controllers.BaseManage
{
    [Route("/BaseManage/[controller]/[action]")]
    public class BaseUserLogController : BaseApiController
    {
        #region DI

        public BaseUserLogController(IBaseUserLogService logBus)
        {
            _logBus = logBus;
        }

        IBaseUserLogService _logBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<BaseUserLog>> GetLogList(PageInput<UserLogsInputDTO> input)
        {
            input.SortField = "CreateTime";
            input.SortType = "desc";

            return await _logBus.GetLogListAsync(input);
        }

        [HttpPost]
        public List<SelectOption> GetLogTypeList()
        {
            return EnumHelper.ToOptionList(typeof(UserLogType));
        }

        #endregion

        #region 提交

        #endregion
    }
}