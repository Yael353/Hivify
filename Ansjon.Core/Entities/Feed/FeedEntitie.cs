


using Ansjon.Core.Entities.Exceptions;

namespace Ansjon.Core.Entities
{
    public class Feed
    {
        private Feed()
        {
            // Required by EF Core
        }
        public Feed(string title, string content)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("Title is required.");
            if (string.IsNullOrWhiteSpace(content))
                throw new DomainException("Content is required.");
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            Title = title;
            Content = content;
            ChangeTitle(title);
            ChangeContent(content);
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
        public Guid AuthorId { get; private set; }


        public void ChangeTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException(
                    "Title is required."
                );

            Title = title.Trim();
        }


        public void ChangeContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new DomainException(
                    "Content is required."
                );

            Content = content.Trim();
        }
    }

}





