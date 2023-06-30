using HRTool.DAL.Repos.VacationRepo;

namespace HRTool.DAL
{
    public class VacationRepo : IVacationRepo
    {
        private readonly HRContext _context;
        public VacationRepo(HRContext context)
        {
            _context = context;
        }
       

        public void CreateVacation(Vacation vacation)
        {
            _context.Vacations.Add(vacation);
        }

        public IEnumerable<Vacation> GetEmployeeVacations(int employeeId)
        {
          return _context.Vacations.Where(v =>v.Id == employeeId);
            
        }

        public int SaveChanges()
        {
           return _context.SaveChanges();
        }

       
    }
}
