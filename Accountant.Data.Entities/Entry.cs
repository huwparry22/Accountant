namespace Accountant.Data.Entities
{
    public class Entry
    {
        public int EntryId { get; set; }

        public int UserId { get; set; }

        public DateTime Created { get; set; }

        public string Description { get; set; }
    }
}
