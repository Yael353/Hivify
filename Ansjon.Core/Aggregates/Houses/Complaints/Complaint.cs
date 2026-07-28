using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Houses.Complaints
{
    public class Complaint : BaseEntity<ComplaintID>
    {

        public string Title { get; private set; }
        public string Description { get; private set; }
        public TenantID TenantId { get; private set; }
        public ComplaintStatus Status { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public DateTime? ResolvedDate { get; private set; }
        public string? ImageUrl { get; private set; }
        public string? AdminComment { get; private set; }
        private Complaint() { }

        private Complaint(ComplaintID id, string title, string description, TenantID tenantId) : base(id)
        {

            TenantId = tenantId;
            Status = ComplaintStatus.New;
            CreatedDate = DateTime.UtcNow;

            SetTitle(title);
            SetDescription(description);
        }

        public static Complaint Create(
            string title,
            string description,
            TenantID tenantId)
        {
            return new Complaint(new ComplaintID(Guid.NewGuid()),
             title,
             description,
             tenantId);
        }


        public void UpdateDetails(string title, string description)
        {
            SetTitle(title);
            SetDescription(description);

            UpdatedDate = DateTime.UtcNow;
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("Title is required.");

            Title = title.Trim();
        }

        private void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description is required.");

            Description = description.Trim();
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