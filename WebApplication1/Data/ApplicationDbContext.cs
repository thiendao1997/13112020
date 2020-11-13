using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Model;
using WebApplication1.ModelViews;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<WebApplication1.ModelViews.EmployeeCreate> EmployeeCreate { get; set; }
        public DbSet<WebApplication1.ModelViews.DepartmentModel> DepartmentModel { get; set; }
    }
}
