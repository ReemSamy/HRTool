namespace HRTool.BL.Dtos.EmployeeDto
{
    public class RemainingBalanceDto
    {
        public RemainingBalanceDto(int balance, int sickBalance)
        {
            AnnualBalance = balance;
            SickBalance = sickBalance;
        }

        public int AnnualBalance { get; set; }
        public int SickBalance { get; set; }
    }
}
