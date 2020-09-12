using Blade.Entity.BaseManage;
using Blade.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Service.BaseManage
{
    public interface IBaseDepartmentService
    {
        Task<List<BaseDepartmentTreeDTO>> GetTreeDataListAsync(DepartmentsTreeInputDTO input);
        Task<BaseDepartment> GetTheDataAsync(string id);
        Task<List<string>> GetChildrenIdsAsync(string departmentId);
        Task AddDataAsync(BaseDepartment newData);
        Task UpdateDataAsync(BaseDepartment theData);
        Task DeleteDataAsync(List<string> ids);
    }

    public class DepartmentsTreeInputDTO
    {
        public string parentId { get; set; }
    }

    public class BaseDepartmentTreeDTO : TreeModel
    {
        public object children { get => Children; }
        public string title { get => Text; }
        public string value { get => Id; }
        public string key { get => Id; }
    }
}