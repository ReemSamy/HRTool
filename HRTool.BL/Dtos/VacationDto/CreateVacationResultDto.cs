namespace HRTool.BL.Dtos.VacationDto
{
    public class CreateVacationResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public CreateVacationResultDto(bool isSuccess,string message)
        { 
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
