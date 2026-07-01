using Ansjon.Core.Entities.Exceptions;

namespace Ansjon.Core.Entities.Feed
{
    public class Feed
    {
        private Feed() { }

        public Feed(Guid authorId, string title, string content)
        {
            if (authorId == Guid.Empty)
                throw new DomainException("Author is required.");

            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            AuthorId = authorId;

            ChangeTitle(title);
            ChangeContent(content);
        }

        public Guid Id { get; private set; }
        public Guid AuthorId { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public void ChangeTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("Title is required.");

            if (title.Length > 200)
                throw new DomainException("Title cannot exceed 200 characters.");

            Title = title.Trim();
        }

        public void ChangeContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new DomainException("Content is required.");

            Content = content.Trim();
        }
    }

}





