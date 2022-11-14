using InstagrannyV2._6.Areas.Identity.Data;
using InstagrannyV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace InstagrannyV2.Pages
{
    public class PostlistModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PostlistModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Posts> Posts;




        public void OnGet()
        {
            Posts = _context.Posts.ToList();

        }
    }
        
        
}
