namespace HRTool.DAL
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Balance { get; set; }
        public IEnumerable<Vacation> VacationRequests { get; set; } =new HashSet<Vacation>();
        
    }
}
