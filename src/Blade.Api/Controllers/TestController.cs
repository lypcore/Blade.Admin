using Blade.Entity.BaseManage;
using Blade.Util;
using EFCore.Sharding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blade.Api.Controllers
{
    [Route("/[controller]/[action]")]
    public class TestController : BaseController
    {
        readonly IDbAccessor _repository;
        public TestController(IDbAccessor repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task PressTest()
        {
            BaseUser BaseUser = new BaseUser
            {
                Id = Guid.NewGuid().ToString(),
                Birthday = DateTime.Now,
                CreateTime = DateTime.Now,
                CreatorId = Guid.NewGuid().ToString(),
                DepartmentId = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                RealName = Guid.NewGuid().ToString(),
                Sex = Sex.Man,
                UserName = Guid.NewGuid().ToString()
            };

            await _repository.InsertAsync(BaseUser);
            await _repository.UpdateAsync(BaseUser);
            await _repository.GetIQueryable<BaseUser>().Where(x => x.Id == BaseUser.Id).FirstOrDefaultAsync();
            await _repository.DeleteAsync(BaseUser);
        }

        [HttpGet]
        public async Task<PageResult<BaseUserLog>> GetLogList()
        {
            return await _repository.GetIQueryable<BaseUserLog>().GetPageResultAsync(new PageInput());
        }
    }
}