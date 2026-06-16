using System;
using System.Collections.Generic;
using System.Text;

namespace Ansjon.UseCases.Communications.dto
{
    public class UpdateFeedDto
    {
        public required Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
