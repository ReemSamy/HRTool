namespace HRTool.DAL
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Balance { get; set; }
        public IEnumerable<Vacation> Vacations { get; set; } =new HashSet<Vacation>();
        
    }
}
