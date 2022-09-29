namespace Accountant.API.Models
{
    public class BaseResponse
    {
        public bool Success { get; set; }

        public IEnumerable<string>? Errors { get; set; }
    }
}
