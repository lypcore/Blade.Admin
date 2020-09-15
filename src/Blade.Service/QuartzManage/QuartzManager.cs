using Blade.Entity.BaseManage;
using Blade.Sugar.Utility;
using Blade.Util;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blade.Service
{
    /// <summary>
    /// 定时任务调用类
    /// </summary>
    public static class QuartzManager
    {
        /// <summary>
        /// 添加CronTrigger定时任务计划
        /// </summary>
        /// <param name="taskData">任务配置信息</param>
        /// <param name="returnMessage">返回提示信息</param>
        /// <returns>是否添加成功</returns>
        public static bool AddCronTriggerTaskAndRun(BaseQuartzTask taskData, ref string returnMessage)
        {
            var db = new DBHelper().GetSugarDB();

            if (taskData == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(taskData.JobName))
            {
                returnMessage = "任务名称不能为空！";
                return false;
            }
            if (string.IsNullOrEmpty(taskData.JobClassName))
            {
                returnMessage = "任务类名称不能为空！";
                return false;
            }
            Type jobClassType = Type.GetType(taskData.JobClassName);//"测试1.SimpleJob"
            if (jobClassType == null)
            {
                returnMessage = "任务类名称有误！";
                return false;
            }
            if (typeof(IJob).IsAssignableFrom(jobClassType) == false)//类必须继承IJob接口
            {
                returnMessage = "任务类必须继承IJob接口！";
                return false;
            }

            taskData.JobGroup = string.IsNullOrWhiteSpace(taskData.JobGroup) ? taskData.JobName : taskData.JobGroup;

                int id = db.Queryable<BaseQuartzTask>().Where(q => q.JobName == taskData.JobName && q.JobGroup == taskData.JobGroup).Select(q => q.Id).Count();
                if (id > 0)
                {
                    returnMessage = "已经存在" + taskData.JobGroup + "组的" + taskData.JobName + "任务名称！";
                    return false;
                }
                taskData.SimpleTriggerRepeatCount = null;//区别一次性任务
                taskData.SimpleTriggerRepeatSeconds = null;
                taskData.CreateTime = DateTime.Now;
                if (taskData.Enabled == true)
                {
                    string cronExpression = !string.IsNullOrEmpty(taskData.CronSecond) ? taskData.CronSecond : "*";
                    cronExpression += " " + (!string.IsNullOrEmpty(taskData.CronMinute) ? taskData.CronMinute : "*");
                    cronExpression += " " + (!string.IsNullOrEmpty(taskData.CronHour) ? taskData.CronHour : "*");
                    cronExpression += " " + (!string.IsNullOrEmpty(taskData.CronDay) ? taskData.CronDay : "*");
                    cronExpression += " " + (!string.IsNullOrEmpty(taskData.CronMonth) ? taskData.CronMonth : "*");
                    cronExpression += " " + (!string.IsNullOrEmpty(taskData.CronWeek) ? taskData.CronWeek : "?");
                    cronExpression += " " + taskData.CronYear ?? string.Empty;

                    bool result = QuartzHelper.AddCronTriggerJob(jobClassType, taskData.JobName, taskData.JobGroup, cronExpression, taskData.StarRunTime, taskData.EndRunTime);//添加定时任务
                    if (result == true)
                    {
                        taskData.RunStatus = (int)QuartzRunStatus.Working;
                    }
                    else
                    {
                        returnMessage = "任务运行失败，请检查配置信息是否正确";
                        return false;
                    }
                }
                else
                {
                    taskData.RunStatus = (int)QuartzRunStatus.Wait;
                }
            db.Insertable(taskData).ExecuteCommand();
            return true;
        }

        /// <summary>
        /// 添加SimpleTrigger定时任务计划(一次性任务)
        /// 一次性任务必须设置运行结束时间
        /// </summary>
        /// <param name="taskData">任务配置信息</param>
        /// <param name="returnMessage">返回提示信息</param>
        /// <returns>是否添加成功</returns>
        public static bool AddSimpleTriggerTaskAndRun(BaseQuartzTask taskData, ref string returnMessage)
        {
            var db = new DBHelper().GetSugarDB();
            if (taskData == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(taskData.JobName))
            {
                returnMessage = "任务名称不能为空！";
                return false;
            }
            if (string.IsNullOrEmpty(taskData.JobClassName))
            {
                returnMessage = "任务类名称不能为空！";
                return false;
            }
            Type jobClassType = Type.GetType(taskData.JobClassName);//"测试1.SimpleJob"
            if (jobClassType == null)
            {
                returnMessage = "任务类名称有误！";
                return false;
            }
            if (typeof(IJob).IsAssignableFrom(jobClassType) == false)//类必须继承IJob接口
            {
                returnMessage = "任务类必须继承IJob接口！";
                return false;
            }
            if (taskData.EndRunTime == null)
            {
                returnMessage = "一次性任务必须设置运行结束时间！";
                return false;
            }

            if (taskData.SimpleTriggerRepeatCount == null)
            {
                taskData.SimpleTriggerRepeatCount = 0.ToString();//默认执行一次
            }
            if (taskData.SimpleTriggerRepeatSeconds == null)
            {
                taskData.SimpleTriggerRepeatSeconds = 1.ToString();//默认一秒执行一次
            }

            taskData.JobGroup = string.IsNullOrWhiteSpace(taskData.JobGroup) ? taskData.JobName : taskData.JobGroup;

                int id = db.Queryable<BaseQuartzTask>().Where(q => q.JobName == taskData.JobName && q.JobGroup == taskData.JobGroup).Select(q => q.Id).Count();
                if (id > 0)
                {
                    returnMessage = "已经存在" + taskData.JobGroup + "组的" + taskData.JobName + "任务名称！";
                    return false;
                }

                taskData.CreateTime = DateTime.Now;
                if (taskData.Enabled == true)
                {
                    bool result = QuartzHelper.AddSimpleTriggerJob(jobClassType, taskData.JobName, taskData.JobGroup, Convert.ToInt32(taskData.SimpleTriggerRepeatCount)
                    , Convert.ToInt32(taskData.SimpleTriggerRepeatSeconds), taskData.StarRunTime, taskData.EndRunTime);//添加定时任务
                    if (result == true)
                    {
                        taskData.RunStatus = (int)QuartzRunStatus.Working;
                    }
                    else
                    {
                        returnMessage = "任务运行失败，请检查配置信息是否正确";
                        return false;
                    }
                }
                else
                {
                    taskData.RunStatus = (int)QuartzRunStatus.Wait;
                }
            db.Insertable(taskData).ExecuteCommand();
            return true;
        }

        /// <summary>
        /// 运行所有配置的定时任务
        /// </summary>
        public static void Run()
        {
            //LinBasic.Log.LogHelper.GetInstance.LogWithTime("Quartz定时任务服务已启动");

            var db = new DBHelper().GetSugarDB();
            List<BaseQuartzTask> taskList = db.Queryable<BaseQuartzTask>().Where(q => q.Enabled == true).ToList();
            if (taskList != null && taskList.Count > 0)
            {
                foreach (BaseQuartzTask taskData in taskList)
                {
                    Type jobClassType = Type.GetType(taskData.JobClassName);//"测试1.MyJob"
                    if (jobClassType == null)
                    {
                        taskData.Message = "任务类名称有误，格式为“类命名空间.类名称”";
                        taskData.RunStatus = (int)QuartzRunStatus.Wait;
                        taskData.ModifyTime = DateTime.Now;
                        continue;
                    }
                    bool result = false;
                    if (taskData.SimpleTriggerRepeatCount == null)
                    {
                        string cronExpression = !string.IsNullOrEmpty(taskData.CronSecond) ? taskData.CronSecond : "*";
                        cronExpression += " " + (!string.IsNullOrEmpty(taskData.CronMinute) ? taskData.CronMinute : "*");
                        cronExpression += " " + (!string.IsNullOrEmpty(taskData.CronHour) ? taskData.CronHour : "*");
                        cronExpression += " " + (!string.IsNullOrEmpty(taskData.CronDay) ? taskData.CronDay : "*");
                        cronExpression += " " + (!string.IsNullOrEmpty(taskData.CronMonth) ? taskData.CronMonth : "*");
                        cronExpression += " " + (!string.IsNullOrEmpty(taskData.CronWeek) ? taskData.CronWeek : "?");
                        cronExpression += " " + taskData.CronYear ?? string.Empty;
                        result = QuartzHelper.AddCronTriggerJob(jobClassType, taskData.JobName, taskData.JobGroup, cronExpression, taskData.StarRunTime, taskData.EndRunTime);
                    }
                    else
                    {
                        if (taskData.SimpleTriggerRepeatSeconds == null)
                        {
                            taskData.SimpleTriggerRepeatSeconds = 1.ToString();//默认一秒执行一次
                        }
                        if (taskData.EndRunTime == null)
                        {
                            taskData.Message = "一次性任务运行结束时间不能为空！";
                            taskData.RunStatus = (int)QuartzRunStatus.Wait;
                            taskData.Enabled = false;
                            taskData.ModifyTime = DateTime.Now;
                            continue;
                        }
                        else if (taskData.EndRunTime > DateTime.Now)
                        {
                            result = QuartzHelper.AddSimpleTriggerJob(jobClassType, taskData.JobName, taskData.JobGroup, Convert.ToInt32(taskData.SimpleTriggerRepeatCount),
                                Convert.ToInt32(taskData.SimpleTriggerRepeatSeconds), taskData.StarRunTime, taskData.EndRunTime);
                        }
                        else
                        {
                            taskData.Message = "任务运行完毕！";
                            taskData.RunStatus = (int)QuartzRunStatus.Wait;
                            taskData.Enabled = false;
                            taskData.ModifyTime = DateTime.Now;
                            continue;
                        }
                    }
                    if (result == true)
                    {
                        taskData.RunStatus = (int)QuartzRunStatus.Working;
                        taskData.Message = string.Empty;
                        taskData.ModifyTime = DateTime.Now;
                    }
                    else
                    {
                        taskData.Message = "任务运行失败，请检查配置信息是否正确";
                    }

                    db.Updateable(taskData).ExecuteCommand();
                }
                QuartzHelper.StartAllJob();
            }
        }
    }
}
