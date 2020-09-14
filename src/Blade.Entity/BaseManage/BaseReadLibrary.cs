using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blade.Entity.BaseManage
{
    /// <summary>
    /// 只读库配置表
    /// </summary>
    [Table("BaseReadLibrary")]
    public class BaseReadLibrary
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
        /// 创建人
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required(ErrorMessage = "描述不能为空")]
        public String Des { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        public Int32 HitRate { get; set; }

        /// <summary>
        /// 连接字符串
        /// </summary>
        [Required(ErrorMessage = "连接字符串不能为空")]
        public String ConnectionString { get; set; }

        /// <summary>
        /// 启用（0禁用，1启用）
        /// </summary>
        public Int32 IsEnable { get; set; }

        /// <summary>
        /// 被链接次数
        /// </summary>
        public Int32 ConnectionTotal { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public String DbType { get; set; }

    }
}