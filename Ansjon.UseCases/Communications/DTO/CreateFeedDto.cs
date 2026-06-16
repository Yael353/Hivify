namespace Ansjon.UseCases.Communications.DTO
{
    public class CreateFeedDto
    {
        public Guid AuthorId { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }

    }

}
