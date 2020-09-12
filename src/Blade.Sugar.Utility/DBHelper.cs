using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;

using SqlSugar;

namespace Blade.Sugar.Utility
{
    public class DBHelper
    {
        private bool useAffectedRows = false;
        private bool isMaindb = false;
        private static string mainConnst = string.Empty;
        private static string dbTypeStr { get; set; }
        private static readonly List<string> readList = new List<string>();
        private static Random ra = new Random();
        private string Addconnst
        {
            get
            {
                if (useAffectedRows)
                    return ";useAffectedRows=true";
                return "";
            }
        }
        /// <summary>
        /// 连接数据库类型
        /// </summary>
        public string DbTypeStr
        {
            get
            {
                return dbTypeStr;
            }
        }
        /// 短连接的数据库连接字符串
        /// </summary>
        public string Connst
        {
            get
            {
                if (isMaindb)
                    return ConcatPar(MainConnst, Addconnst);
                return ConcatPar(ReadonlyConnst, Addconnst);
            }
        }
        private string _mainConnst = string.Empty;
        /// <summary>
        /// 获取或设置连接主数据库的字符串
        /// </summary>
        public string MainConnst
        {
            get
            {
                if (string.IsNullOrEmpty(_mainConnst))
                    return ConcatPar(MainConnString, Addconnst);
                return ConcatPar(_mainConnst, Addconnst);
            }
            set
            {
                _mainConnst = value;
            }
        }

        private string readonlyConnst = string.Empty;
        /// <summary>
        /// 获取或设置连接只读数据库的字符串
        /// </summary>
        public string ReadonlyConnst
        {
            get
            {
                if (string.IsNullOrEmpty(readonlyConnst))
                    return ConcatPar(ReadOnlyConnString, Addconnst);
                return ConcatPar(readonlyConnst, Addconnst);
            }
            set
            {
                readonlyConnst = value;
            }
        }
        /// <summary>
        /// 获取或设置主数据库连接字符串（初始化必须设置）
        /// </summary>
        public static string MainConnString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(mainConnst))
                    throw new DBHelperException("主库连接字符串为空");
                return mainConnst;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DBHelperException("不能把空字符串设置为主库连接");
                mainConnst = value;
            }
        }
        private string ConcatPar(string connst, string addpar)
        {
            StringBuilder sb = new StringBuilder(connst);
            string connst_lower = connst.ToLower();
            string[] ss = addpar.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string par in ss)
            {
                if (!connst_lower.Contains(par.ToLower()))
                    sb.Append($";{par}");
            }
            return sb.ToString();
        }
        public static void GetDbType(string dbType)
        {
            dbTypeStr = dbType;
        }
        /// <summary>
        /// 添加只读数据库连接字符串
        /// </summary>
        /// <param name="connst">只读数据库连接字符串</param>
        /// <returns></returns>
        public static int AddReadConnString(string connst)
        {
            if (string.IsNullOrWhiteSpace(connst))
                throw new DBHelperException("不能把空字符串设置为只读库连接");
            readList.Add(connst);
            return readList.Count;
        }
        /// <summary>
        /// 只读数据库连接字符串
        /// </summary>
        public static string ReadOnlyConnString
        {
            get
            {
                if (readList.Count == 0) //没有添加只读数据库连接字符串就用主数据库的
                    return MainConnString;
                string connst = readList[ra.Next(readList.Count)];
                if (string.IsNullOrWhiteSpace(connst))
                    throw new DBHelperException("只读连接字符串为空");
                return connst;
            }
        }
        /// <summary>
        /// 重新配置连接字符串
        /// </summary>
        /// <param name="mainconnst">主数据连接字符串</param>
        /// <param name="readConnsts">只读数据库连接字符串数组</param>
        /// <param name="cleanPoolConnect">是否重置时清除旧连接的连接池</param>
        public async static void ReSetConnst(string mainconnst, string[] readConnsts = null, bool cleanPoolConnect = false)
        {
            if (cleanPoolConnect)
            {
                if (!string.IsNullOrEmpty(mainConnst) && mainConnst != mainconnst)
                    using (MySqlConnection conn = new MySqlConnection(mainConnst))
                        await conn.ClearAllPoolsAsync();
                if (readConnsts != null)
                {
                    List<string> tl = new List<string>();
                    tl.AddRange(readConnsts);
                    foreach (string connst in readList)
                    {
                        if (!tl.Contains(connst))
                        {
                            using (MySqlConnection conn = new MySqlConnection(connst))
                                await conn.ClearAllPoolsAsync();
                        }
                    }
                    tl.Clear();
                    tl = null;
                }
            }
            MainConnString = mainconnst;
            if (readConnsts != null)
            {
                readList.Clear();
                foreach (string connst in readConnsts)
                    AddReadConnString(connst);
            }
        }

        /// <summary>
        /// 返回SqlSugar对象
        /// </summary>
        /// <param name="showSqlOnConsole">执行操作数据库时是否打印SQL到控制台</param>
        /// <param name="initKeyType">Attribute   不受数据库限制通过实体特性读取，如果找不到主键什么的都改用Attribute方式老老实实给实体加特性
        /// SystemTable  从数据库系统表查询，这种需要SA这种高权限账号，对纯MODEL有洁癖的用户适用</param>
        /// <returns></returns>
        public SqlSugarClient GetSugarDB(bool showSqlOnConsole = true, InitKeyType initKeyType = InitKeyType.Attribute)
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = Connst,
                DbType = DbHelperFactory.GetDbType(DbTypeStr),//设置数据库类型
                IsAutoCloseConnection = true,//自动释放数据务，如果存在事务，在事务结束后释放
                InitKeyType = InitKeyType.Attribute, //从实体特性中读取主键自增列信息
                //SlaveConnectionConfigs = new List<SlaveConnectionConfig>()
                //    {//从连接
                //         new SlaveConnectionConfig() { HitRate=10, ConnectionString="Data Source=.;Initial Catalog=Blade.Admin1;Integrated Security=True;Pooling=true;" },
                //         new SlaveConnectionConfig() { HitRate=30, ConnectionString="Data Source=.;Initial Catalog=Blade.Admin2;Integrated Security=True;Pooling=true;" }
                //     },
                AopEvents = new AopEvents
                {
                    OnLogExecuting = (sql, p) =>
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(sql);
                        Console.WriteLine(string.Join(",", p?.Select(it => it.ParameterName + ":" + it.Value)));
                        Console.WriteLine("--------------------------------");
                    }
                }
            });
            Console.WriteLine(db.Ado.Connection.ConnectionString);
            return db;
        }
    }
}
