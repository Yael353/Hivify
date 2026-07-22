using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;
namespace Ansjon.Core.Aggregates.Feeds
{

    public class Feed : BaseEntity, IAggregateRoot
    {
        public ComplaintID FeedId { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public Guid AuthorId { get; private set; }
        public DateTime CreatedDate { get; private set; }

        private Feed() { }

        private Feed(Guid authorId, string title, string content)
        {
            if (authorId == Guid.Empty)
                throw new DomainException("Author is required.");

            FeedId = new ComplaintID(Guid.NewGuid());
            CreatedDate = DateTime.UtcNow;
            AuthorId = authorId;

            SetTitle(title);
            SetContent(content);
        }

        public static Feed CreateFeed(Guid authorId, string title, string content)
        {
            return new Feed(authorId, title, content);
        }


        public void Update(string title, string content)
        {
            SetTitle(title);
            SetContent(content);
        }


        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("Title is required.");

            if (title.Length > 200)
                throw new DomainException("Title cannot exceed 200 characters.");

            Title = title.Trim();
        }

        private void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new DomainException("Content is required.");

            if (content.Length > 1000)
                throw new DomainException("Content cannot exceed 1000 characters.");

            Content = content.Trim();
        }
    }
}