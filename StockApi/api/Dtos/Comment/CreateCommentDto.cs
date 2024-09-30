using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title Must be at least 5 Charactes")]
        [MaxLength(256, ErrorMessage = "Title Cannot Be Over 256 Characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Content Must be at least 5 Charactes")]
        [MaxLength(256, ErrorMessage = "Content Cannot Be Over 256 Characters")]
        public string Content { get; set; } = string.Empty;
    }
}