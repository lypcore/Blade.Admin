using SqlSugar;
using System;

namespace Blade.Sugar.Utility
{
    /// <summary>
    /// 数据库帮助类工厂
    /// </summary>
    public class DbHelperFactory
    {
        /// <summary>
        /// 获取指定的数据库帮助类
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="conString">连接字符串</param>
        /// <returns></returns>
        public static DbType GetDbType(string dbType)
        {
            dbType = dbType.ToLower();
            switch (dbType)
            {
                case "sqlserver": return DbType.SqlServer;
                case "mysql": return DbType.MySql;
                case "oracle": return DbType.Oracle;
                case "postgresql": return DbType.PostgreSQL;
                case "sqlite": return DbType.Sqlite;
                default: throw new Exception("暂不支持");
            }
        }
    }
}

