using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Note.Models
{
    public class NoteEntity
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
