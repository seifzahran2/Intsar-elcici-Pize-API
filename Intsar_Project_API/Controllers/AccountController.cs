using Castle.Core.Smtp;
using Intsar_Project_API.Models;
using Intsar_Project_API.Models.ViewModels;
using Intsar_Project_API.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
namespace Intsar_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService userService;
        public AccountController(IUserService userService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.userService = userService;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await userService.RegisterAsync(registerVM);
            if (!result.IsAuthed)
                return BadRequest(result.Message);
            return Ok(new {token=result.Token,expirOn = result.ExpireOn, Check = true });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login( LoginVM loginVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await userService.LoginAsync(loginVM);
            if (!result.IsAuthed)
                return BadRequest(new { result.Message ,result.Check});
            return Ok(new { token = result.Token, expirOn = result.ExpireOn ,Check= true });

        }

        

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await userService.LogoutAsync();
            return Ok("تم تسجيل الخروج");
        }

    }
}
