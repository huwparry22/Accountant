namespace Accountant.API.Models.Responses.User
{
    public class GetUserResponse : BaseResponse
    {
        public int UserId { get; set; }

        public string? EmailAddress { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
