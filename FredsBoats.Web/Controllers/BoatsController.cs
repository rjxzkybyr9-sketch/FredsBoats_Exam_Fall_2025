using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FredsBoats.Web.Data;
using FredsBoats.Web.Models;

namespace FredsBoats.Web.Controllers
{
    public class BoatsController : Controller
    {
        private readonly FredsBoatsContext _context;

        public BoatsController(FredsBoatsContext context)
        {
            _context = context;
        }

        // GET: Boats
        public async Task<IActionResult> Index()
        {
            var boats = _context.Boats
                .Include(b => b.Category)
                .Include(b => b.BoatColour);
            return View(await boats.ToListAsync());
        }

        // GET: Boats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var boat = await _context.Boats
                .Include(b => b.Category)
                .Include(b => b.BoatColour)
                .Include(b => b.Comments)
                // We include this in anticipation of the exam task (Comments)
                // but for now it will just prevent errors if the property exists
                .FirstOrDefaultAsync(m => m.BoatId == id);

            if (boat == null) return NotFound();

            return View(boat);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(int BoatId, string Author, string Content)
        {
            // 1. Create the new comment object 
            var comment = new Comment
            {
                BoatId = BoatId,
                Author = Author,
                Content = Content,
                CreatedAt = DateTime.Now
            };

            // 2. Add to database and save (MUST be inside the method)
            _context.Add(comment);
            await _context.SaveChangesAsync();

            // 3. Go back to details page to see the new comment
            return RedirectToAction("Details", new { id = BoatId });
        }

    }
}