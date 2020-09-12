using EFCore.Sharding;

namespace Blade.Util
{
    public class DatabaseOptions
    {
        public string ConnectionString { get; set; }
        public DatabaseType  DatabaseType { get; set; }
    }
}
