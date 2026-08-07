using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;
using Ansjon.Core.SharedKernel.ValuesObjects;

namespace Ansjon.Core.Aggregates.Feeds
{

    public class Feed : BaseEntity<FeedID>, IAggregateRoot
    {

        public Title Title { get; private set; }
        public Description Content { get; private set; }
        public MemberID AuthorId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        private Feed() { }  // Private constructor for EF Core

        private Feed(FeedID id, MemberID authorId, Title title, Description content)
        : base(id)
        {
            CreatedDate = DateTime.UtcNow;
            AuthorId = authorId;

            SetTitle(title);
            SetContent(content);
        }


        public static Feed CreateFeed(
          MemberID authorId,
          MemberRole role,
          Title title,
          Description content)
        {
            EnsureAdmin(role);

            return new Feed(new FeedID(Guid.NewGuid()), authorId, title, content);
        }


        public void Update(Title title, Description content, MemberRole role)
        {
            EnsureAdmin(role);
            EnsureNotDeleted();
            SetTitle(title);
            SetContent(content);
        }

        public void Delete(MemberRole role)
        {
            EnsureAdmin(role);
            EnsureNotDeleted();

            DeletedAt = DateTime.UtcNow;
        }


        // Validation methods for the Feed aggregate
        private void SetTitle(Title title)
        {
            Title = title;
        }

        private void SetContent(Description content)
        {
            Content = content;
        }




        // business rules
        private void EnsureNotDeleted()
        {
            if (DeletedAt != null)
                throw new DomainException("Feed has already been deleted.");
        }
        private static void EnsureAdmin(MemberRole role)
        {
            if (role != MemberRole.GeneralMember)
                throw new DomainException(
                    "Only administrators can manage feeds.");
        }
    }
}