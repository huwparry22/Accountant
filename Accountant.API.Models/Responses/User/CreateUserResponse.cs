using Accountant.API.Models.Interfaces;

namespace Accountant.API.Models.Responses.User
{
    public class CreateUserResponse : BaseResponse, IUser
    {
        public Models.User User { get; set; }
    }
}
