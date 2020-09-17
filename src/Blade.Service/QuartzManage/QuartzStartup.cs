using Blade.Service.QuartzManage.TaskManage;
using Blade.Util;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Blade.Service.QuartzManage
{
    public class QuartzStartup : ISingletonDependency
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _iocJobfactory;
        private IScheduler _scheduler;
        public QuartzStartup(IJobFactory iocJobfactory, ISchedulerFactory schedulerFactory)
        {
            //1、声明一个调度工厂
            this._schedulerFactory = schedulerFactory;
            this._iocJobfactory = iocJobfactory;
            NameValueCollection properties = new NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "FenlaQuartz";

            // set thread pool info
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            int threadCount = 20;//LoadDeputySet.GetInstance.Load().QuartzThreadCount;
            threadCount = threadCount > 0 ? threadCount : 20;
            properties["quartz.threadPool.threadCount"] = threadCount.ToString();//线程数
            properties["quartz.threadPool.threadPriority"] = "Normal";
        }
        public async Task<string> Start()
        {
            #region MyRegion
            //Type t0 = Type.GetType("Blade.Service.QuartzManage.TaskManage.QuartzTestJob");
            //Type t1 = Type.GetType("Blade.Service.QuartzManage.TaskManage.QuartzTestJob2");
            //for (int i = 0; i < 2; i++)
            //{
            //    //2、通过调度工厂获得调度器
            //    _scheduler = await _schedulerFactory.GetScheduler();
            //    _scheduler.JobFactory = this._iocJobfactory;//  替换默认工厂
            //                                                //3、开启调度器
            //    await _scheduler.Start();
            //    ////4、创建一个触发器
            //    //var trigger = TriggerBuilder.Create()
            //    //                .StartAt(DateTime.Now.AddSeconds(20))//开始启动时间
            //    //                .EndAt(DateTime.Now.AddSeconds(40))

            //    //                .WithSimpleSchedule(x => x.WithIntervalInSeconds(2).RepeatForever())//每两秒执行一次
            //    //                .Build();

            //    //5、创建任务

            //    if (i == 0)
            //    {
            //        //4、创建一个触发器
            //        var trigger = TriggerBuilder.Create()
            //                        .StartAt(DateTime.Now.AddSeconds(20))//开始启动时间
            //                        .EndAt(DateTime.Now.AddSeconds(40))

            //                        .WithSimpleSchedule(x => x.WithIntervalInSeconds(2).RepeatForever())//每两秒执行一次
            //                        .Build();
            //        IJobDetail jobDetail = JobBuilder.Create(t0)
            //        .WithIdentity("job", "group")
            //        .Build();
            //        //6、将触发器和任务器绑定到调度器中
            //        await _scheduler.ScheduleJob(jobDetail, trigger);

            //    }
            //    if (i == 1)
            //    {
            //        //4、创建一个触发器
            //        var trigger = TriggerBuilder.Create()
            //                        //.StartAt(DateTime.Now.AddSeconds(20))//开始启动时间
            //                        //.EndAt(DateTime.Now.AddSeconds(40))
            //                        .WithCronSchedule("5 * * 1/1 * ? ")
            //                        //.WithSimpleSchedule(x => x.WithIntervalInSeconds(2).RepeatForever())//每两秒执行一次
            //                        .Build();
            //        IJobDetail jobDetail = JobBuilder.Create(t1)
            //        .WithIdentity("job1", "group1")
            //        .Build();
            //        //6、将触发器和任务器绑定到调度器中
            //        await _scheduler.ScheduleJob(jobDetail, trigger);
            //    }
            //}
            //return await Task.FromResult("将触发器和任务器绑定到调度器中完成");
            #endregion

            return await Task.FromResult("将触发器和任务器绑定到调度器中完成");
        }
        public void Stop()
        {
            if (_scheduler == null)
            {
                return;
            }

            if (_scheduler.Shutdown(waitForJobsToComplete: true).Wait(30000))
                _scheduler = null;
            else
            {
            }
        }
    }
}