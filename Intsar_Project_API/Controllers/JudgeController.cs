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
    [Authorize(Roles = "Judge")]
    [Route("api/[controller]")]
    [ApiController]
    public class JudgeController : Controller
    {
        private AppDbContext _App;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        public JudgeController(AppDbContext App, UserManager<ApplicationUser> applicationUser, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _App = App;
            _userManager = applicationUser;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var judge = await _userManager.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
            var user = _App.compRegs.Where(c => c.project_type == judge.Specialization).ToList();
            return Ok(user);
        }

        [HttpGet]
        [Route("compInfo")]
        public IActionResult compInfo(int id)
        {
            var user = _App.degComps.Where(b => b.compRegId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }
        [HttpGet]
        [Route("compRate")]
        public IActionResult compRate(int id)
        {
            var user = _App.compRegs.Where(b => b.Id == id).FirstOrDefault();
            var userProject = _App.projects.Where(b => b.Email == user.Email).FirstOrDefault();
            return Ok(userProject);
        }

        [HttpPost]
        [Route("compRate/id")]
        public IActionResult compRate(int id, DegCompsVM degCompVM)
        {
            var user = _App.compRegs.Where(b => b.Id == id).FirstOrDefault();
            var user2 = _App.degComps.Where(b => b.compRegId == id).FirstOrDefault();
            if (user2 != null)
            {
                var degUserr = _App.degComps.Where(c => c.compRegId == id).FirstOrDefault();
                degUserr.ProjectIdea = degCompVM.ProjectIdea;
                degUserr.ExecutionQuality = degCompVM.ExecutionQuality;
                degUserr.Gui = degCompVM.Gui;
                degUserr.ContentQuality = degCompVM.ContentQuality;
                degUserr.complexity = degCompVM.complexity;
                degUserr.ProjectBbenefit = degCompVM.ProjectBbenefit;
                degUserr.language_Tools = degCompVM.language_Tools;
                degUserr.MasteringTheTools = degCompVM.MasteringTheTools;
                degUserr.InfrastructureUsed = degCompVM.InfrastructureUsed;
                degUserr.Notes = degCompVM.Notes;
                degUserr.OverallRating = degCompVM.OverallRating;
                degUserr.Email = user.Email;
                degUserr.compRegId = id;
                _App.SaveChanges();
            }
            
            var degUser = new DegComp()
            {
                ProjectIdea = degCompVM.ProjectIdea,
                ExecutionQuality = degCompVM.ExecutionQuality,
                Gui = degCompVM.Gui,
                ContentQuality = degCompVM.ContentQuality,
                complexity = degCompVM.complexity,
                ProjectBbenefit = degCompVM.ProjectBbenefit,
                language_Tools = degCompVM.language_Tools,
                MasteringTheTools = degCompVM.MasteringTheTools,
                InfrastructureUsed = degCompVM.InfrastructureUsed,
                Notes = degCompVM.Notes,
                OverallRating = degCompVM.OverallRating,
                Email = user.Email,
                compRegId = id,
            };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _App.Add(degUser);
            _App.SaveChanges();
            return Ok("تم التقييم");
        }

        [HttpGet]
        [Route("Profile")]
        public async Task<IActionResult> Profile()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
            var profUser = new ProfileVM();
            profUser = new ProfileVM
            {
                Name = user.Name,
                Email = user.Email,
                age = user.age,
                mobileNumber = user.mobileNumber,
                NationalID = user.NationalID,
                gender = user.gender,
                project_type = user.Specialization
            };

            return Ok(profUser);
        }
    }
}
