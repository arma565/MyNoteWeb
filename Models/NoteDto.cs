using System.ComponentModel.DataAnnotations;

namespace Note.Models
{
    public class NoteDto
    {
        [Required, StringLength(100)]
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
