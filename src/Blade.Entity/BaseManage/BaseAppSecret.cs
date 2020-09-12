using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blade.Entity.BaseManage
{
    /// <summary>
    /// 应用密钥表
    /// </summary>
    [Table("BaseAppSecret")]
    public class BaseAppSecret
    {

        /// <summary>
        /// 自然主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 否已删除
        /// </summary>
        public Boolean Deleted { get; set; }

        /// <summary>
        /// 应用Id
        /// </summary>
        public String AppId { get; set; }

        /// <summary>
        /// 应用密钥
        /// </summary>
        public String AppSecret { get; set; }

        /// <summary>
        /// 应用名
        /// </summary>
        public String AppName { get; set; }

    }
}