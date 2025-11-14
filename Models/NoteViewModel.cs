using System.ComponentModel.DataAnnotations;

namespace Note.Models
{
    public class NoteViewModel
    {
        [Required, StringLength(100)]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<NoteEntity>? Notes { get; set; }
        public string? SearchString { get; set; }
    }
}
