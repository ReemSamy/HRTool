namespace HRTool.BL.Services
{
    public interface ICalculationServices
    {
        int CalculateDeductedBalance(DateTime startDate, DateTime endDate);
    }
}