using Microsoft.EntityFrameworkCore;

namespace HRTool.DAL.Repos.VacationRepo
{
    public interface IVacationRepo
    {
        void CreateVacation(Vacation vacation);
        IEnumerable<Vacation> GetEmployeeVacations(int employeeId);
        int SaveChanges();
        
    }
}
