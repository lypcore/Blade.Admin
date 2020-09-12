using Blade.Service.BaseManage;
using Blade.IService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Api.Controllers.BaseManage
{
    /// <summary>
    /// 首页控制器
    /// </summary>
    [Route("/BaseManage/[controller]/[action]")]
    public class HomeController : BaseApiController
    {
        readonly IHomeService _homeBus;
        readonly IPermissionService _permissionBus;
        readonly IBaseUserService _userBus;
        readonly IOperator _operator;
        public HomeController(
            IHomeService homeBus,
            IPermissionService permissionBus,
            IBaseUserService userBus,
            IOperator @operator
            )
        {
            _homeBus = homeBus;
            _permissionBus = permissionBus;
            _userBus = userBus;
            _operator = @operator;
        }

        /// <summary>
        /// 用户登录(获取token)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [NoCheckJWT]
        public async Task<string> SubmitLogin(LoginInputDTO input)
        {
            return await _homeBus.SubmitLoginAsync(input);
        }

        [HttpPost]
        public async Task ChangePwd(ChangePwdInputDTO input)
        {
            await _homeBus.ChangePwdAsync(input);
        }

        [HttpPost]
        public async Task<object> GetOperatorInfo()
        {
            var theInfo = await _userBus.GetTheDataAsync(_operator.UserId);
            var permissions = await _permissionBus.GetUserPermissionValuesAsync(_operator.UserId);
            var resObj = new
            {
                UserInfo = theInfo,
                Permissions = permissions
            };

            return resObj;
        }

        [HttpPost]
        public async Task<List<BaseActionDTO>> GetOperatorMenuList()
        {
            return await _permissionBus.GetUserMenuListAsync(_operator.UserId);
        }
    }
}