using Ansjon.Core.Aggregates.Association.Staff;
using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;
using Ansjon.Core.ValuesObjects;
namespace Ansjon.Core.Aggregates.Feeds
{

    public class Feed : BaseEntity<FeedID>, IAggregateRoot
    {

        public Title Title { get; private set; }
        public Description Content { get; private set; }
        public StaffMemberID AuthorId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        private Feed() { }  // Private constructor for EF Core

        private Feed(FeedID id, StaffMemberID authorId, Title title, Description content)
        : base(id)
        {
            CreatedDate = DateTime.UtcNow;
            AuthorId = authorId;

            SetTitle(title);
            SetContent(content);
        }


        public static Feed CreateFeed(
          StaffMemberID authorId,
          StaffRole role,
          Title title,
          Description content)
        {
            EnsureAdmin(role);

            return new Feed(new FeedID(Guid.NewGuid()), authorId, title, content);
        }


        public void Update(Title title, Description content, StaffRole role)
        {
            EnsureAdmin(role);
            EnsureNotDeleted();
            SetTitle(title);
            SetContent(content);
        }

        public void Delete(StaffRole role)
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
        private static void EnsureAdmin(StaffRole role)
        {
            if (role != StaffRole.Admin)
                throw new DomainException(
                    "Only administrators can manage feeds.");
        }
    }
}