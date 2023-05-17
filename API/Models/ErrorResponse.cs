namespace API.Models
{
    internal class ErrorResponse
    {
        public string Message { get; set; } = string.Empty;
        public string StackTrace { get; set; } = string.Empty;
    }
}