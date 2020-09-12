using Blade.Entity.BaseManage;
using Blade.Util;
using System.Collections.Generic;

namespace Blade.Entity
{
    [Map(typeof(BaseUser))]
    public class BaseUserDTO : BaseUser
    {
        public string RoleNames { get => string.Join(",", RoleNameList ?? new List<string>()); }
        public List<string> RoleIdList { get; set; }
        public List<string> RoleNameList { get; set; }
        public RoleTypes RoleType
        {
            get
            {
                int type = 0;

                var values = typeof(RoleTypes).GetEnumValues();
                foreach (var aValue in values)
                {
                    if (RoleNames.Contains(aValue.ToString()))
                        type += (int)aValue;
                }

                return (RoleTypes)type;
            }
        }
        public string DepartmentName { get; set; }
        public string SexText { get => Sex.GetDescription(); }
        public string BirthdayText { get => Birthday?.ToString("yyyy-MM-dd"); }
    }
}
