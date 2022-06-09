using Intsar_Project_API.Data;
using Intsar_Project_API.Models;
using Intsar_Project_API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Intsar_Project_API.Controllers
{
    [Authorize(Roles ="Comp")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompController : Controller
    {
        private AppDbContext _App;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public CompController(AppDbContext App, UserManager<ApplicationUser> applicationUser, SignInManager<ApplicationUser> signInManager)
        {
            _App = App;
            _userManager = applicationUser;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Route("UploadProjectAsync")]
        public async Task<IActionResult> UploadProjectAsync(_ProjectVM projectVM)
        {

            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();

            var compSp = _App.compRegs.Where(b => b.Email == user.Email).FirstOrDefault();
            if (projectVM.DriveLink == null)
            {
                return BadRequest("برجاء ادخال رابط درايف الخاص بمشروعك");
            }
            if(compSp.IsprojecSent==true)
            {
                return BadRequest("تم ارسال المشروع سابقا ، اذا كان هناك مشكلة برجاء لاتواصل معنا");
            }
            var project = new _project()
            {
                DriveLink = projectVM.DriveLink,
                Specialization = compSp.project_type,
                Email = compSp.Email
            };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            compSp.IsprojecSent = true;
            _App.Add(project);
            _App.SaveChanges();
            user.IsProjSent = true;
            await _userManager.UpdateAsync(user);
            return Ok("تم ارسال المشروع");
        }

        
        [HttpGet]
        [Route("Profile")]
        public async Task<IActionResult> Profile()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
            var comp = _App.compRegs.Where(b => b.Email == user.Email).FirstOrDefault();
            var profUser = new ProfileVM();
            if (comp != null)
            {
                profUser = new ProfileVM
                {
                    Name = user.Name,
                    Email = user.Email,
                    age = user.age,
                    mobileNumber = user.mobileNumber,
                    NationalID = user.NationalID,
                    gender = user.gender,
                    project_type = comp.project_type,
                    Educational_level = comp.Educational_level,
                    AgeType = comp.AgeType,
                    educational_system = comp.educational_system
                };
            }
            
            return Ok(profUser);
        }
    }
}
