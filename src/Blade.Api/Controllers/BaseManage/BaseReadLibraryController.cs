using Blade.Service.BaseManage;
using Blade.Entity.BaseManage;
using Blade.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Api.Controllers.BaseManage
{
    [Route("/BaseManage/[controller]/[action]")]
    public class BaseReadLibraryController : BaseApiController
    {
        #region DI

        public BaseReadLibraryController(IBaseReadLibraryService baseReadLibraryBus)
        {
            _baseReadLibraryBus = baseReadLibraryBus;
        }

        IBaseReadLibraryService _baseReadLibraryBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<BaseReadLibrary>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _baseReadLibraryBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<BaseReadLibrary> GetTheData(IdInputDTO input)
        {
            return await _baseReadLibraryBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(BaseReadLibrary data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _baseReadLibraryBus.AddDataAsync(data);
            }
            else
            {
                await _baseReadLibraryBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _baseReadLibraryBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}