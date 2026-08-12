using Ansjon.Core.Aggregates.Complaints;
using System.ComponentModel.DataAnnotations;

namespace Ansjon.UseCases.Complaints.DTOs
{
    public class UpdateComplaintDto
    {
        [Required(ErrorMessage = "Titel är obligatorisk")]
        [StringLength(200, ErrorMessage = "Titeln får vara max 200 tecken")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Beskrivning är obligatorisk")]
        [StringLength(1000, ErrorMessage = "Beskrivningen får vara max 1000 tecken")]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }
        public ComplaintStatus? Status { get; set; }
        public string? AdminComment { get; set; }
    }
}