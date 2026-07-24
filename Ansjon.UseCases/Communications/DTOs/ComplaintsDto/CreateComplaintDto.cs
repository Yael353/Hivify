using System.ComponentModel.DataAnnotations;

namespace Ansjon.UseCases.Communications.DTOs.ComplaintsDto
{
    public class CreateComplaintDto
    {
        [Required(ErrorMessage = "Titel är obligatorisk")]
        [StringLength(200, ErrorMessage = "Titel får inte vara längre än 200 tecken")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Beskrivning är obligatorisk")]
        [StringLength(1000, ErrorMessage = "Beskrivning får inte vara längre än 1000 tecken")]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}