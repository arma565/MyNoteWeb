using Microsoft.EntityFrameworkCore;
using Note.Models;

namespace Note.Data
{
    public class NoteDbContext(DbContextOptions<NoteDbContext> options) : DbContext(options)
    {
        public DbSet<NoteEntity> Notes { get; set; } = default!;
    }
}
