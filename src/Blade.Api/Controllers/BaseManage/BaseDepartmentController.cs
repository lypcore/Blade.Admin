using Blade.IService.BaseManage;
using Blade.Entity.BaseManage;
using Blade.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Api.Controllers.BaseManage
{
    [Route("/BaseManage/[controller]/[action]")]
    public class BaseDepartmentController : BaseApiController
    {
        #region DI

        public BaseDepartmentController(IBaseDepartmentService departmentBus)
        {
            _departmentBus = departmentBus;
        }

        IBaseDepartmentService _departmentBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<BaseDepartment> GetTheData(IdInputDTO input)
        {
            return await _departmentBus.GetTheDataAsync(input.id) ?? new BaseDepartment();
        }

        [HttpPost]
        public async Task<List<BaseDepartmentTreeDTO>> GetTreeDataList(DepartmentsTreeInputDTO input)
        {
            return await _departmentBus.GetTreeDataListAsync(input);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(BaseDepartment theData)
        {
            if (theData.Id.IsNullOrEmpty())
            {
                InitEntity(theData);

                await _departmentBus.AddDataAsync(theData);
            }
            else
            {
                await _departmentBus.UpdateDataAsync(theData);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _departmentBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}