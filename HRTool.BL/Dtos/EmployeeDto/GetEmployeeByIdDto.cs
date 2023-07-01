using HRTool.DAL;

namespace HRTool.BL
{
    public class GetEmployeeByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Balance { get; set; }

    }
}
