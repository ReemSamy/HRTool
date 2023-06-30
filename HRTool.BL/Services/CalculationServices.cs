using Microsoft.Extensions.Configuration;

namespace HRTool.BL.Services
{
    public class CalculationServices : ICalculationServices
    {
        private readonly IConfiguration _configuration;

        public CalculationServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int CalculateDeductedBalance(DateTime startDate, DateTime endDate)
        {
            var NationalHolidays = _configuration.GetSection("NationalHolidays").Get<HashSet<DateTime>>()!;
            int totalDays = 0;
            while (startDate <= endDate)
            {
                bool isWeekend = startDate.DayOfWeek == DayOfWeek.Friday
                    || startDate.DayOfWeek == DayOfWeek.Saturday;
                bool isNationalHoliday = NationalHolidays.Contains(startDate);
                startDate = startDate.AddDays(1);
                if (!isWeekend && !isNationalHoliday)
                {
                    totalDays++;
                }
            }
            return totalDays;
        }
    }
}
