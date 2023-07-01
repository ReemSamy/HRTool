using HRTool.DAL;

namespace HRTool.BL
{
    public class CreateVacationDto
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VacationType VacationType { get; set; } 
    }
}
