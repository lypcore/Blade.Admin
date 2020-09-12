using Blade.Entity.BaseManage;
using Blade.Util;
using System.Collections.Generic;

namespace Blade.Service.BaseManage
{
    public interface IBuildCodeService
    {
        List<BaseDbLink> GetAllDbLink();

        List<DbTableInfo> GetDbTableList(string linkId);

        void Build(BuildInputDTO input);
    }

    public class DbTablesInputDTO
    {
        public string linkId { get; set; }
    }

    public class BuildInputDTO
    {
        public string linkId { get; set; }
        public string areaName { get; set; }
        public List<string> tables { get; set; }
        public List<int> buildTypes { get; set; }
    }
}
