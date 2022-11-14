using InstagrannyV2._6.Areas.Identity.Data;

using InstagrannyV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InstagrannyV2.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // lists for statistics involving User table 
        public List<Users> Users = new List<Users>();
        public List<Users> oldestUsers = new List<Users>();
        public List<Users> newestUsers = new List<Users>();
        public List<Users> activeUsers = new List<Users>();

        //lists for statistics involving Posts table
        public float AveragePosts {get; set;}
        public int totalPics { get; set;}

        public List<Posts> Posts = new List<Posts>();

        // list for statistics involving Comments table

        public List<Comments> Comments = new List<Comments>();
        
        public void OnGet()
        {
            Users = _context.Users.ToList();
            Posts = _context.Posts.ToList();
            Comments = _context.Comments.ToList();
            
            //code for users

            var oldest = from user in _context.Users
                              orderby user.Date_joined
                              select user;

            var oldestthree = oldest.Take(3);

            oldestUsers = oldestthree.ToList();


            var newest = from user in _context.Users
                         orderby user.Date_joined descending
                         select user;
            
            var newestthree = newest.Take(3);
            
            newestUsers = newestthree.ToList();

            DateTime date = DateTime.Now.AddDays(-15);                  
            var active = from user in _context.Users
                         where (DateTime)user.Last_login > date
                         select user;

            activeUsers = active.ToList();


            // code for posts
            
            float totalUsers = _context.Users.Count();
            float totalPosts = _context.Posts.Count();          

            float averagePosts = totalPosts / totalUsers;
            AveragePosts = (float)Math.Round( averagePosts,2);
        
            var photoPosts = from post in _context.Posts
                                where string.IsNullOrEmpty(post.ImageUrl) == false
                                select post;

            totalPics = photoPosts.Count();

        
        
        
        }


    }

}
