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

            #region Seeding Data 
            var employees = new List<Employee>
{
    new ()
    {
        Id = 1,
        Name = "John Doe",
        AnnualBalance = 21,
        SickBalance = 50,
    },
    new ()
    {
        Id = 2,
        Name = "Jane Smith",
        AnnualBalance = 21,
        SickBalance=50,
    },
    new ()
    {
        Id = 3,
        Name = "Mark Johnson",
        AnnualBalance = 21,
        SickBalance=50,
    }
            };



            var vacations = new List<Vacation>
{


         new ()
         {
             Id = 1,
             EmployeeId = 1,
             StartDate = new DateTime(2023, 7, 1),
             EndDate = new DateTime(2023, 7, 5),
             RequestDay = new DateTime(2023, 6, 30),
             VacationType = VacationType.Annual
         },
         new ()
         {
             Id = 2,
             EmployeeId = 1,
             StartDate = new DateTime(2023, 8, 15),
             EndDate = new DateTime(2023, 8, 20),
             RequestDay = new DateTime(2023, 7, 1),
             VacationType = VacationType.Sick
         },
         new ()
         {
             Id = 3,
             EmployeeId = 2,
             StartDate = new DateTime(2023, 7, 10),
             EndDate = new DateTime(2023, 7, 15),
             RequestDay = new DateTime(2023, 6, 30),
             VacationType = VacationType.Annual
         },
         new ()
         {
             Id = 4,
             EmployeeId = 3,
             StartDate = new DateTime(2023, 7, 20),
             EndDate = new DateTime(2023, 7, 25),
             RequestDay = new DateTime(2023, 6, 30),
             VacationType = VacationType.Annual
         },
         new ()
         {
             Id = 5,
             EmployeeId = 3,
             StartDate = new DateTime(2023, 8, 5),
             EndDate = new DateTime(2023, 8, 8),
             RequestDay = new DateTime(2023, 7, 1),
             VacationType = VacationType.Annual
         }

};

            #endregion

            builder.Entity<Employee>().HasData(employees);
            builder.Entity<Vacation>().HasData(vacations);

        }

    }

}

