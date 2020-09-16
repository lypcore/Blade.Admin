using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blade.Service.QuartzManage
{
    public class QuartzStartup
    {
        public async Task<string> Start()
        {
            await Task.Run(() =>
            {
                QuartzManager.Run();
            });
            return "定时任务已启动!!!";
        }
    }
}
