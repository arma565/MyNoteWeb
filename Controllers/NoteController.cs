using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Note.Data;
using Note.Models;
using System.Threading.Tasks;

namespace Note.Controllers
{
    public class NoteController(NoteDbContext context) : Controller
    {
        private readonly NoteDbContext _context = context;

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] NoteViewModel noteViewModel, CancellationToken ct = default)
        {
            if (ModelState.IsValid)
            {
                var note = new NoteEntity
                {

                    Title = noteViewModel.Title,
                    Description = noteViewModel.Description
                };
                await _context.AddAsync(note, ct);
                await _context.SaveChangesAsync(ct);
                return RedirectToAction(nameof(Index));
            }
            return View(noteViewModel);
        }


        public IActionResult Index(string searchString)
        {
            if(_context.Notes == null)
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            IQueryable<NoteEntity> notesQuery = from n in _context.Notes.OrderByDescending(n => n.Id) select n;

            if (!searchString.IsNullOrEmpty())
                notesQuery = notesQuery.Where(n => n.Title!.ToUpper().Contains(searchString.ToUpper()));
            
            var noteViewModel = new NoteViewModel{
                Notes = notesQuery.ToList()
            };

            return View(noteViewModel);
        }

        public async Task<IActionResult> Details(int? id) { 
            if (id == null)
                return NotFound();
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
            if (note == null)
                return NotFound();
            return View(note);
        }

        public async Task<IActionResult> Edit(int? id) {
            if(id == null)
                return NotFound();
            var note =  await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
            if (note == null)
                return NotFound();
            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [FromForm] NoteEntity note,CancellationToken ct)
        {
            if (id != note.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try {
                    _context.Update(note);
                    await _context.SaveChangesAsync(ct);
                }
                catch (DbUpdateConcurrencyException) {
                    if (!NoteExist(note.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }

        

        public async Task <IActionResult> Delete(int? id) {
            if (id == null)
                return NotFound();
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
            if (note == null)
                return NotFound();

            return View(note);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id) { 
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
                _context.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExist(int id) =>  _context.Notes.Any(n => n.Id == id);
    }
}
