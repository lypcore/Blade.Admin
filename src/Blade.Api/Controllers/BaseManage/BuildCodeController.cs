using Blade.Service.BaseManage;
using Blade.Entity.BaseManage;
using Blade.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Blade.Api.Controllers.BaseManage
{
    [Route("/BaseManage/[controller]/[action]")]
    public class BuildCodeController : BaseApiController
    {
        #region DI

        public BuildCodeController(IBuildCodeService buildCodeBus)
        {
            _buildCodeBus = buildCodeBus;
        }

        IBuildCodeService _buildCodeBus { get; }

        #endregion

        [HttpPost]
        public List<BaseDbLink> GetAllDbLink()
        {
            return _buildCodeBus.GetAllDbLink();
        }

        [HttpPost]
        public List<DbTableInfo> GetDbTableList(DbTablesInputDTO input)
        {
            return _buildCodeBus.GetDbTableList(input.linkId);
        }

        [HttpPost]
        public void Build(BuildInputDTO input)
        {
            _buildCodeBus.Build(input);
        }
    }
}