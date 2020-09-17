using Blade.Util;
using Quartz;
using System;
using System.Threading.Tasks;

namespace Blade.Service.QuartzManage.TaskManage
{
    public class QuartzTestJob : IJob, ITransientDependency
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                //.....
                Console.WriteLine($"{DateTime.Now}：开始执行同步第三方数据");
                //....同步操作

            });
        }
    }
}