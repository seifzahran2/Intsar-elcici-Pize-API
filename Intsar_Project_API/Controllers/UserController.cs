using Intsar_Project_API.Data;
using Intsar_Project_API.Helpers;
using Intsar_Project_API.Models;
using Intsar_Project_API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Intsar_Project_API.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppDbContext _App;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public UserController(AppDbContext App, UserManager<ApplicationUser> applicationUser, SignInManager<ApplicationUser> signInManager)
        {
            _App = App;
            _userManager = applicationUser;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Route("CompRegs")]
        public async Task<IActionResult> CompRegs(compRegVM compRegVM)
        {
            var RegModel = new compRegVM();
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
            if (user.IsRegSent == true)
            {
                RegModel.Message = "تم التسجيل في المسابقه بالفعل";
                RegModel.Check = false;
                return BadRequest(new { RegModel.Message, RegModel.Check });
            }

            
            var compReg = new CompReg()
            {
                FullName = compRegVM.FullName,
                Email = compRegVM.Email,
                Address = compRegVM.Address,
                BankAccount = compRegVM.BankAccount,
                NationalId = compRegVM.NationalId,
                Age = compRegVM.Age,
                CompNum = compRegVM.CompNum,
                Gender = compRegVM.Gender,
                project_type = compRegVM.project_type,
                Educational_level = compRegVM.Educational_level,
                AgeType = compRegVM.AgeType,
                educational_system = compRegVM.educational_system,

            };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (user.Email != compRegVM.Email || user.NationalID != compRegVM.NationalId)
            {
                RegModel.Message = "يجب ان يكون الرقم القومي و البريد الالكتروني مطابق لتسجيل الدخول ، راجع صفحتك الشخصية.";
                RegModel.Check = false;
                return BadRequest(new { RegModel.Message, RegModel.Check });
            }

            _App.compRegs.Add(compReg);
            _App.SaveChanges();
            user.IsRegSent = true;
            user.Specialization = compRegVM.project_type;
            await _userManager.UpdateAsync(user);
            return Ok("تم ارسال طلب التسجيل في المسابقة");
        }

        [HttpGet]
        [Route("Profile")]
        public async Task<IActionResult> Profile()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.Users.Where(u=>u.UserName== username).FirstOrDefaultAsync();
            var profUser = new ProfileVM();
            profUser = new ProfileVM
            {
                Name = user.Name,
                Email = user.Email,
                age = user.age,
                mobileNumber = user.mobileNumber,
                NationalID = user.NationalID,
                gender = user.gender,
            };
            
            return Ok(profUser);
        }
    }
}
