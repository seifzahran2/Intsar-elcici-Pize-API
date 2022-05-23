using Intsar_F_Project.Models;
using Intsar_Project_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Intsar_Project_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {

        }
        public DbSet<CompReg> compRegs { get; set; }
        public DbSet<DegComp> degComps { get; set; }
        public DbSet<_project> projects { get; set; }
        public DbSet<Contact> contacts { get; set; }
    }
}
