namespace HRTool.BL.Dtos.VacationDto
{
    public class CalculateBalanceDto
    {
        public CalculateBalanceDto(int balance)
        {
            Balance = balance;
        }

        public int Balance { get; set; }
    }
}
