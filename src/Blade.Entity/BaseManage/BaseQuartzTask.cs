using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blade.Entity.BaseManage
{
    /// <summary>
    /// BaseQuartzTask
    /// </summary>
    [Table("BaseQuartzTask")]
    public class BaseQuartzTask
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public String JobName { get; set; }

        /// <summary>
        /// 任务所属分组
        /// </summary>
        public String JobGroup { get; set; }

        /// <summary>
        /// 任务类名
        /// </summary>
        public String JobClassName { get; set; }

        /// <summary>
        /// 任务描述
        /// </summary>
        public String JobDescription { get; set; }

        /// <summary>
        /// 运行状态 0：未运行 10：运行中 20：暂停
        /// </summary>
        public Int32 RunStatus { get; set; }

        /// <summary>
        /// 0：禁用 1：启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 开始运行时间
        /// </summary>
        public DateTime? StarRunTime { get; set; }

        /// <summary>
        /// 运行结束时间
        /// </summary>
        public DateTime? EndRunTime { get; set; }

        /// <summary>
        /// 秒
        /// </summary>
        public String CronSecond { get; set; }

        /// <summary>
        /// 分钟
        /// </summary>
        public String CronMinute { get; set; }

        /// <summary>
        /// 小时
        /// </summary>
        public String CronHour { get; set; }

        /// <summary>
        /// 日
        /// </summary>
        public String CronDay { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        public String CronMonth { get; set; }

        /// <summary>
        /// 星期
        /// </summary>
        public String CronWeek { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        public String CronYear { get; set; }

        /// <summary>
        /// 执行信息
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        /// 重复执行次数
        /// </summary>
        public String SimpleTriggerRepeatCount { get; set; }

        /// <summary>
        /// 重复执行时间间隔
        /// </summary>
        public String SimpleTriggerRepeatSeconds { get; set; }

    }

    /// <summary>
    /// 定时任务调用枚举
    /// </summary>
    public enum QuartzRunStatus
    {
        /// <summary>
        /// 未运行
        /// </summary>
        Wait = 0,

        /// <summary>
        /// 运行中
        /// </summary>
        Working = 10,

        /// <summary>
        /// 暂停
        /// </summary>
        Pause = 20
    }
}