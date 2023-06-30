using Microsoft.EntityFrameworkCore;

namespace HRTool.DAL
{
    public class HRContext : DbContext
    {
       
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
       

        public HRContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }

}

