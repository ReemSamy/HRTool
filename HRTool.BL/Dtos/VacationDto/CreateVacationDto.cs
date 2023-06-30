using HRTool.DAL;

namespace HRTool.BL
{
    public class CreateVacationDto
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string VacationType { get; set; } = string.Empty;
        public int Duration { get; set; }
    }
}
