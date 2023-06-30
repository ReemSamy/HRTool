using HRTool.DAL;

namespace HRTool.BL
{
    public class GetEmployeeByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Balance { get; set; }
        public IEnumerable<Vacation> VacationRequests { get; set; } = new HashSet<Vacation>();
        public IEnumerable<Vacation> Vacations { get; set; } = new HashSet<Vacation>();

    }
}
