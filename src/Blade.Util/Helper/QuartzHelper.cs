using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;

namespace Blade.Util
{
    /// <summary>
    /// 定时任务调度帮助基类
    /// 注意：job和trigger使用相同的jobName和jobGroup    
    /// </summary>
    public static class QuartzHelper
    {
        private static ISchedulerFactory scheduleFactory = null;

        static QuartzHelper()
        {
            System.Collections.Specialized.NameValueCollection properties = new System.Collections.Specialized.NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "FenlaQuartz";

            // set thread pool info
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            int threadCount = 20;//LoadDeputySet.GetInstance.Load().QuartzThreadCount;
            threadCount = threadCount > 0 ? threadCount : 20;
            properties["quartz.threadPool.threadCount"] = threadCount.ToString();//线程数
            properties["quartz.threadPool.threadPriority"] = "Normal";

            scheduleFactory = new StdSchedulerFactory(properties);
        }

        /// <summary>
        /// 添加CronTrigger类型的定时任务
        /// </summary>
        /// <typeparam name="T">实现具体业务逻辑的类</typeparam>
        /// <param name="jobClassType"></param>
        /// <param name="jobName">任务名称</param>
        /// <param name="jobGroup">任务所属分组</param>
        /// <param name="cronExpression">Cron时间表达式[秒 分 时 日 月 星期 年(可选)]</param>
        /// <param name="startRunTime">任务开始时间</param>
        /// <param name="endRunTime">任务结束时间</param>
        /// <param name="param">传递给任务类的参数</param>
        /// <returns></returns>
        public static bool AddCronTriggerJob(Type jobClassType, string jobName, string jobGroup, string cronExpression, DateTime? startRunTime, DateTime? endRunTime, Dictionary<string, object> param = null)
        {
            if (typeof(IJob).IsAssignableFrom(jobClassType) == false) { return false; }//任务类必须继承IJob接口
            if (string.IsNullOrEmpty(cronExpression)) { return false; }

            try
            {
                if (startRunTime == null)
                {
                    startRunTime = DateTime.Now;
                }
                DateTimeOffset starRunTimeTemp = DateBuilder.NextGivenSecondDate(startRunTime, 1);//开始时间
                DateTimeOffset? endRunTimeTemp = null;//结束时间
                if (endRunTime != null)
                {
                    if (endRunTime.Value < startRunTime.Value)
                    {
                        return false;
                    }
                    endRunTimeTemp = DateBuilder.NextGivenSecondDate(endRunTime, 1);
                }
                //首先创建一个作业调度池
                IScheduler schedule = (IScheduler)scheduleFactory.GetScheduler();
                //创建出来一个具体的作业
                IJobDetail jobDetail = JobBuilder.Create(jobClassType).WithIdentity(jobName, jobGroup).Build();
                if (param != null && param.Count > 0)
                {
                    foreach (string key in param.Keys)
                    {
                        jobDetail.JobDataMap.Put(key, param[key]);
                    }
                }
                //创建并配置一个触发器
                ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                                                        .StartAt(starRunTimeTemp)
                                                        .EndAt(endRunTimeTemp)
                                                        .WithIdentity(jobName, jobGroup)
                                                        .WithCronSchedule(cronExpression)
                                                        .Build();
                //加入作业调度池中
                schedule.ScheduleJob(jobDetail, trigger);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 添加SimpleTrigger类型的定时任务
        /// </summary>
        /// <typeparam name="T">实现具体业务逻辑的类</typeparam>
        /// <param name="jobClassType"></param>
        /// <param name="jobName">任务名称</param>
        /// <param name="jobGroup">任务所属分组</param>
        /// <param name="repeatCount">重复次数</param>
        /// <param name="repeatIntervalSeconds">重复调用时间间隔</param>
        /// <param name="startRunTime">任务开始时间</param>
        /// <param name="endRunTime">任务结束时间</param>
        /// <param name="param">传递给任务类的参数[context.JobDetail.JobDataMap.GetString("key")获取]</param>
        /// <returns></returns>
        public static bool AddSimpleTriggerJob(Type jobClassType, string jobName, string jobGroup, int repeatCount, int repeatIntervalSeconds, DateTime? startRunTime, DateTime? endRunTime, Dictionary<string, object> param = null)
        {
            if (typeof(IJob).IsAssignableFrom(jobClassType) == false) { return false; }//任务类必须继承IJob接口
            repeatIntervalSeconds = repeatIntervalSeconds <= 0 ? 1 : repeatIntervalSeconds;
            repeatCount = repeatCount < -1 ? -1 : repeatCount;

            try
            {
                if (startRunTime == null)
                {
                    startRunTime = DateTime.Now;
                }
                DateTimeOffset starRunTimeTemp = DateBuilder.NextGivenSecondDate(startRunTime, 1);//开始时间
                DateTimeOffset? endRunTimeTemp = null;//结束时间
                if (endRunTime != null)
                {
                    if (endRunTime.Value < startRunTime.Value)
                    {
                        return false;
                    }
                    endRunTimeTemp = DateBuilder.NextGivenSecondDate(endRunTime, 1);
                }
                //首先创建一个作业调度池
                IScheduler schedule = (IScheduler)scheduleFactory.GetScheduler();
                //创建出来一个具体的作业
                IJobDetail jobDetail = JobBuilder.Create(jobClassType).WithIdentity(jobName, jobGroup).Build();
                if (param != null && param.Count > 0)
                {
                    foreach (string key in param.Keys)
                    {
                        jobDetail.JobDataMap.Put(key, param[key]);
                    }
                }
                //创建并配置一个触发器
                ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
                                                        .StartAt(starRunTimeTemp)
                                                        .EndAt(endRunTimeTemp)
                                                        .WithIdentity(jobName, jobGroup)
                                                        .WithSimpleSchedule(x => x.WithIntervalInSeconds(repeatIntervalSeconds).WithRepeatCount(repeatCount))
                                                        .Build();
                //加入作业调度池中
                schedule.ScheduleJob(jobDetail, trigger);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改CronTrigger任务的触发时间规则
        /// </summary>
        /// <param name="jobName">任务名称</param>
        /// <param name="jobGroup">任务所属分组</param>
        /// <param name="cronExpression">Cron时间表达式[秒 分 时 日 月 星期 年(可选)]</param>
        /// <returns></returns>
        public static bool ModifyCronTriggerJobTime(string jobName, string jobGroup, string cronExpression)
        {
            try
            {
                IScheduler schedule = (IScheduler)scheduleFactory.GetScheduler();
                ICronTrigger trigger = (ICronTrigger)schedule.GetTrigger(new TriggerKey(jobName, jobGroup));
                if (trigger == null)
                {
                    return false;
                }
                string oldCron = trigger.CronExpressionString;
                if (oldCron != cronExpression)
                {
                    schedule.PauseTrigger(new TriggerKey(jobName, jobGroup));
                    trigger.CronExpressionString = cronExpression;
                    schedule.RescheduleJob(new TriggerKey(jobName, jobGroup), trigger);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改SimpleTrigger任务的触发规则
        /// </summary>
        /// <param name="jobName">任务名称</param>
        /// <param name="jobGroup">任务所属分组</param>
        /// <param name="repeatCount">重复次数</param>
        /// <param name="repeatIntervalSeconds">重复时间间隔</param>
        /// <returns></returns>
        public static bool ModifySimpleTriggerJobTime(string jobName, string jobGroup, int repeatCount, int repeatIntervalSeconds)
        {
            try
            {
                IScheduler schedule = (IScheduler)scheduleFactory.GetScheduler();
                ISimpleTrigger trigger = (ISimpleTrigger)schedule.GetTrigger(new TriggerKey(jobName, jobGroup));
                if (trigger == null)
                {
                    return false;
                }
                int oldRepeatCount = trigger.RepeatCount;
                int oldRepeatInterval = trigger.RepeatInterval.Seconds;
                bool reset = false;
                if (oldRepeatCount != repeatCount || oldRepeatInterval != repeatIntervalSeconds)
                {
                    reset = true;
                }
                if (reset == true)
                {
                    schedule.PauseTrigger(new TriggerKey(jobName, jobGroup));
                    trigger.RepeatCount = repeatCount;
                    trigger.RepeatInterval = new TimeSpan(0, 0, repeatIntervalSeconds);
                    schedule.RescheduleJob(new TriggerKey(jobName, jobGroup), trigger);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除指定任务
        /// </summary>
        /// <param name="jobName">任务名称</param>
        /// <param name="jobGroup">任务所属分组</param>
        /// <returns></returns>
        public static bool DeleteJob(string jobName, string jobGroup)
        {
            try
            {
                IScheduler schedule = (IScheduler)scheduleFactory.GetScheduler();
                schedule.PauseTrigger(new TriggerKey(jobName, jobGroup));  //停止触发器
                schedule.UnscheduleJob(new TriggerKey(jobName, jobGroup)); //删除触发器
                schedule.DeleteJob(new JobKey(jobName, jobGroup)); //删除任务
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 重启指定任务
        /// </summary>
        /// <param name="jobName">任务名称</param>
        /// <param name="jobGroup">任务所属分组</param>
        /// <returns></returns>
        public static bool ResumeJob(string jobName, string jobGroup)
        {
            try
            {
                IScheduler schedule = (IScheduler)scheduleFactory.GetScheduler();
                schedule.ResumeJob(new JobKey(jobName, jobGroup));
                schedule.ResumeTrigger(new TriggerKey(jobName, jobGroup));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 暂停指定任务
        /// </summary>
        /// <param name="jobName">任务名称</param>
        /// <param name="jobGroup">任务所属分组</param>
        /// <returns></returns>
        public static bool PauseJob(string jobName, string jobGroup)
        {
            try
            {
                IScheduler schedule = (IScheduler)scheduleFactory.GetScheduler();
                schedule.PauseTrigger(new TriggerKey(jobName, jobGroup));
                schedule.PauseJob(new JobKey(jobName, jobGroup));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 启动所有任务
        /// </summary>
        /// <returns></returns>
        public static bool StartAllJob()
        {
            try
            {
                IScheduler schedule = (IScheduler)scheduleFactory.GetScheduler();
                schedule.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 关闭所有任务
        /// </summary>
        /// <param name="waitForJobsToComplete">是否等待任务完毕后关闭</param>
        /// <returns>是否全部关闭成功</returns>
        public static bool ShutDownJobs(bool waitForJobsToComplete)
        {
            try
            {
                IScheduler schedule = (IScheduler)scheduleFactory.GetScheduler();
                if (!schedule.IsShutdown)
                {
                    schedule.Shutdown();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 检测任务运行状态
        /// 当状态为Normal、Blocked，表示任务正在运行
        /// </summary>
        /// <param name="jobName">任务名称</param>
        /// <param name="jobGroup">任务所属分组</param>
        /// <returns></returns>
        public static TriggerState IsRun(string jobName, string jobGroup)
        {
            try
            {
                IScheduler schedule = (IScheduler)scheduleFactory.GetScheduler();
                if (schedule.IsStarted == false)
                {
                    return TriggerState.None;
                }

                return TriggerState.None; //schedule.GetTriggerState(new TriggerKey(jobName, jobGroup));
            }
            catch (Exception)
            {
            }
            return TriggerState.None;
        }

        // 扩展注意点：
        // 1.一个trigger只能对应一个job，同一个job可以定义多个trigger（多个trigger 各自独立的执行调度）
        // 2.同一个jobGroup中多个job的name不能相同，若未设置jobGroup则所有未设置group的job为同一个分组
        // 3.同一个triggerGroup中多个trigger的name不能相同
    }
}