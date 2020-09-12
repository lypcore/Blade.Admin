using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blade.Entity.BaseManage
{
    /// <summary>
    /// 系统角色表
    /// </summary>
    [Table("BaseRole")]
    public class BaseRole
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
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 否已删除
        /// </summary>
        public Boolean Deleted { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public String RoleName { get; set; }

    }
}