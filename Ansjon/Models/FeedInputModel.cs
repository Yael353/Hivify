using System.ComponentModel.DataAnnotations;

namespace Ansjon.Models
{
    public class FeedInputModel
    {
        [Required(ErrorMessage = "Titel är obligatorisk")]
        [StringLength(200, ErrorMessage = "Titeln får vara max 200 tecken")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Innehåll är obligatoriskt")]
        public string Content { get; set; } = string.Empty;
    }
}
