using Ansjon.Core.Enums;
using Ansjon.Core.Exceptions;

namespace Ansjon.Core.Aggregates.Complaints
{
    public class Complaint
    {
        private Complaint()
        {
        }

        public Complaint(string title, string description, Guid authorId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("Title is required.");
            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description is required.");


            ComplaintId = Guid.NewGuid();
            Title = title.Trim();
            Description = description.Trim();
            AuthorId = authorId;
            Status = ComplaintStatus.New;
            CreatedDate = DateTime.UtcNow;
        }

        public Guid ComplaintId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Guid AuthorId { get; private set; }
        public ComplaintStatus Status { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public DateTime? ResolvedDate { get; private set; }
        public string? ImageUrl { get; private set; }
        public string? AdminComment { get; private set; }

        public void UpdateDetails(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("Title is required.");
            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description is required.");

            Title = title.Trim();
            Description = description.Trim();
            UpdatedDate = DateTime.UtcNow;
        }

        public void SetImage(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                throw new DomainException("Image URL is required.");
            ImageUrl = imageUrl;
            UpdatedDate = DateTime.UtcNow;
        }

        public void UpdateStatus(ComplaintStatus newStatus)
        {
            Status = newStatus;
            UpdatedDate = DateTime.UtcNow;

            if (newStatus == ComplaintStatus.Resolved)
            {
                ResolvedDate = DateTime.UtcNow;
            }
        }

        public void AddAdminComment(string comment)
        {
            if (string.IsNullOrWhiteSpace(comment))
                throw new DomainException("Admin comment is required.");
            AdminComment = comment.Trim();
            UpdatedDate = DateTime.UtcNow;
        }
    }
}