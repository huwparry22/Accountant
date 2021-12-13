namespace Accountant.Data.Entities
{
    public class LineItem
    {
        public int LineItemId { get; set; }

        public int UserId { get; set; }

        public DateTime Created { get; set; }

        public string Description { get; set; }
    }
}
