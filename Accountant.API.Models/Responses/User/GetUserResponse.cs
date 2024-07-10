using Accountant.API.Models.Interfaces;

namespace Accountant.API.Models.Responses.User
{
    public class GetUserResponse : BaseResponse, IUser
    {
        public API.Models.User User { get; set; }
    }
}
