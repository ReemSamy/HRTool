using System.ComponentModel.DataAnnotations.Schema;

namespace HRTool.DAL
{
        public enum VacationType
        {
            Annual,
            Sick
        }
    public class Vacation
    {
        public int Id { get; set; } 
        public int EmployeeId { get; set; }
        [Column(TypeName ="Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime RequestDay { get; set; }    
        public VacationType VacationType { get; set; } 
        public Employee? Employee { get; set; }
    }
}
