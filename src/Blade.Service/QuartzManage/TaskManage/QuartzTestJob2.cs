using Blade.Util;
using Quartz;
using System;
using System.Threading.Tasks;

namespace Blade.Service.QuartzManage.TaskManage
{
    public class QuartzTestJob2 : IJob, ITransientDependency
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                //.....
                Console.WriteLine($"{DateTime.Now}：开始执行同步第三方数据6666");
                //....同步操作

            });
        }
    }
}