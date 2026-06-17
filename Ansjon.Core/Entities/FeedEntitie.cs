namespace Ansjon.Core.Entities
{
    public class Feed
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public Guid AuthorId { get; set; }

    }

}


