using InstagrannyV2._6.Areas.Identity.Data;
using InstagrannyV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InstagrannyV2._6.Pages
{
    public class DeletePostModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeletePostModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]        
        public Posts Posts { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            

            if (posts == null)
            {
                return NotFound();
            }
            else
            {
                Posts = posts;
                
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }
            var posts = await _context.Posts.FindAsync(id);

            if (posts != null)
            {
                Posts = posts;
                _context.Posts.Remove(Posts);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Postlist");
        }
    }
}
