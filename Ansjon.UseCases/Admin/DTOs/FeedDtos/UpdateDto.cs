using System.ComponentModel.DataAnnotations;

namespace Ansjon.UseCases.Admin.DTOs.FeedDtos
{
    public class UpdateFeedDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
