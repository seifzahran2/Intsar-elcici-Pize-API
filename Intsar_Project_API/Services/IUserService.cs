using Intsar_Project_API.Models;
using Intsar_Project_API.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Intsar_Project_API.Services
{
    public interface IUserService
    {
        Task<AuthVM> RegisterAsync(RegisterVM model);
        Task<AuthVM> LoginAsync(LoginVM model);
        Task<string> LogoutAsync();
    }
}
