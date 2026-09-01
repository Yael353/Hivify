using Hivify.Core.Complaints;
using System.ComponentModel.DataAnnotations;

namespace Hivify.UseCases.Complaints.DTOs;

public class CreateComplaintDto
{
    [Required(ErrorMessage = "Kategori är obligatorisk")]
    public ComplaintCategory Category { get; set; }

    [Required(ErrorMessage = "Titel är obligatorisk")]
    [StringLength(200, ErrorMessage = "Titeln får vara max 200 tecken")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Beskrivning är obligatorisk")]
    [StringLength(2000, ErrorMessage = "Beskrivningen får vara max 2000 tecken")]
    public string Description { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }
}