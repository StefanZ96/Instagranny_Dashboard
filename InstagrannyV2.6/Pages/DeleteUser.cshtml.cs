using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InstagrannyV2.Models;
using InstagrannyV2._6.Areas.Identity.Data;

namespace InstagrannyV2._6.Pages
{
    public class DeleteUserModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Profiles Profiles { get; set; }
        public Users Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Profiles == null)
            {
                return NotFound();
            }

            var profiles = await _context.Profiles.FirstOrDefaultAsync(m => m.Id == id);
            var users = await _context.Users.FirstOrDefaultAsync(u => u.Id == profiles.UserId);

            if (profiles == null)
            {
                return NotFound();
            }
            else
            {
                Profiles = profiles;
                Users = users;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Profiles == null)
            {
                return NotFound();
            }
            var profiles = await _context.Profiles.FindAsync(id);
            var users = await _context.Users.FirstOrDefaultAsync(u => u.Id == profiles.UserId);

            if (profiles != null)
            {
                Profiles = profiles;
                Users = users;
                _context.Profiles.Remove(Profiles);
                _context.Users.Remove(Users);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Userlist");
        }
    }
}

