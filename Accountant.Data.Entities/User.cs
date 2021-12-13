namespace Accountant.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public int UserName { get; set; }

        public string EmailAddress { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}