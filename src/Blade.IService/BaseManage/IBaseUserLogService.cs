using Blade.Entity.BaseManage;
using Blade.Util;
using System;
using System.Threading.Tasks;

namespace Blade.IService.BaseManage
{
    public interface IBaseUserLogService
    {
        Task<PageResult<BaseUserLog>> GetLogListAsync(PageInput<UserLogsInputDTO> input);
    }

    public class UserLogsInputDTO
    {
        public string logContent { get; set; }
        public string logType { get; set; }
        public string opUserName { get; set; }
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
    }
}