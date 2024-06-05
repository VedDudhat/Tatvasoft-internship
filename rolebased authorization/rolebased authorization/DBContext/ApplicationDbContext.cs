using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rolebased_authorization.Models;
namespace rolebased_authorization.DBContext
{
   

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        protected readonly IConfiguration Configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));         

        }
        public DbSet<LoginModel> Email { get; set; }
        public DbSet<LoginModel> Password { get; set; }
        public DbSet<RegisterModel> Role { get; set; }
    }
}
