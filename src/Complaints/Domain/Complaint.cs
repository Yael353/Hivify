using Hivify.Core.Exceptions;
using Hivify.Core.SharedKernel;
using Hivify.Core.SharedKernel.ValuesObjects;

namespace Hivify.Core.Complaints
{
    public class Complaint : BaseEntity<ComplaintID>, IAggregateRoot
    {
        public UserID UserId { get; private set; }
        public ComplaintCategory Category { get; private set; }
        public Title Title { get; private set; }
        public Description Description { get; private set; }
        public string? ImageUrl { get; private set; }
        public ComplaintStatus Status { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public DateTime? ResolvedDate { get; private set; }
        public string? AdminComment { get; private set; }

        private Complaint() { }

        private Complaint(
            ComplaintID id,
            UserID userId,
            ComplaintCategory category,
            Title title,
            Description description,
            string? imageUrl)
            : base(id)
        {
            UserId = userId;
            Category = category;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            Status = ComplaintStatus.Ny;
            CreatedDate = DateTime.UtcNow;
        }

        public static Complaint Create(
            UserID userId,
            ComplaintCategory category,
            Title title,
            Description description,
            string? imageUrl = null)
        {
            return new Complaint(
                new ComplaintID(Guid.NewGuid()),
                userId,
                category,
                title,
                description,
                imageUrl);
        }

        public void UpdateDetails(Title title, Description description)
        {
            Title = title ?? throw new DomainException("Du måste ange en titel.");
            Description = description ?? throw new DomainException("Du måste ange en beskrivning.");
            UpdatedDate = DateTime.UtcNow;
        }

        public void SetImage(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                throw new DomainException("Ange en bild URL.");
            ImageUrl = imageUrl;
            UpdatedDate = DateTime.UtcNow;
        }

        public void UpdateStatus(ComplaintStatus newStatus)
        {
            Status = newStatus;
            UpdatedDate = DateTime.UtcNow;

            if (newStatus == ComplaintStatus.Löst)
            {
                ResolvedDate = DateTime.UtcNow;
            }
        }

        public void AddAdminComment(string comment)
        {
            if (string.IsNullOrWhiteSpace(comment))
                throw new DomainException("Adminkommentar krävs.");
            AdminComment = comment.Trim();
            UpdatedDate = DateTime.UtcNow;
        }
    }
}