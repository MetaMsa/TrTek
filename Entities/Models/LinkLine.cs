namespace Entities.Models
{
    public class LinkLine
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}