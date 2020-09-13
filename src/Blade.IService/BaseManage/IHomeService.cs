using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Blade.IService.BaseManage
{
    public interface IHomeService
    {
        Task<string> SubmitLoginAsync(LoginInputDTO input);
        Task ChangePwdAsync(ChangePwdInputDTO input);
    }

    public class LoginInputDTO
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }
    }

    public class ChangePwdInputDTO
    {
        [Required]
        public string oldPwd { get; set; }

        [Required]
        public string newPwd { get; set; }
    }
}
