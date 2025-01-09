using CDRMS_Web_Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CDRMS_Web_Application.Data
{
    public class ApplicationDbContext : IdentityDbContext<UsersModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Mark DepartmentsModel as keyless
            //builder.Entity<DepartmentsModel>(entity =>
            //{
            //    entity.HasNoKey();
            //});
        }

        public DbSet<UsersModel> ApplicationUsers { get; set; }
        public DbSet<DepartmentsModel> Departments { get; set; }

        public DbSet<TrunksModel> Trunks { get; set; }
    }
}
