using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InstagrannyV2.Models;
using InstagrannyV2._6.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;


namespace InstagrannyV2._6.Pages
{
    [Authorize]
    public class EditInformationModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditInformationModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Profiles EditProfiles { get; set; } = default!;
        [BindProperty]
        public Users EditUsers { get; set; } = default!;

        public Profiles Profiles { get; set; } = default!;
        public Users Users { get; set; } = default!;

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
            
            Profiles = profiles;
            Users = users;
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == profile.UserId);


            profile.Bio = EditProfiles.Bio;
            user.Username = EditUsers.Username;          

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfilesExists(Profiles.Id))
               {
                    return NotFound();
               }
                else
               {
                   throw;
               }
            }

            return RedirectToPage("/Userlist");
        }

        private bool ProfilesExists(int id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}
