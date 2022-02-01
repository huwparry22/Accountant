using Accountant.API.Models.Common;

namespace Accountant.API.Models
{
    public class BaseResponse
    {
        public bool Success { get; set; }

        public Error? Error { get; set; }
    }
}
