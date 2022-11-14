using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InstagrannyV2.Models;
using InstagrannyV2._6.Areas.Identity.Data;

namespace InstagrannyV2.Pages
{
    public class UserDetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UserDetailModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Users Users { get; set; }
        public Profiles Profiles { get; set; }

        public List<Posts> Posts = new List<Posts>();
        public List<Posts> UserPosts = new List<Posts>();
        public List<Comments> Comments = new List<Comments>();
        public List<Comments> UserComments = new List<Comments>();
        public List<Followers> Followers = new List<Followers>();
        public List<Followers> UserFollowings = new List<Followers>();
        public List<Followers> UserFollowers = new List<Followers>();        

        public int AccountTenure { get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            var userprofiles = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == id);
            Posts = _context.Posts.ToList();
            Comments = _context.Comments.ToList();
            Followers = _context.Followers.ToList();

            if (users == null)
            {
                return NotFound();
            }
            else
            {
                Users = users;
                Profiles = userprofiles;

                var posts = from post in Posts
                            where post.creatorId == id
                            select post;

                UserPosts = posts.ToList();

                var comments = from comms in Comments
                               where comms.creatorId == id
                               select comms;

                UserComments = comments.ToList();

                var userFollowings = from follower in Followers
                                     where follower.UserId == id
                                     select follower;

                UserFollowings = userFollowings.ToList();

                var userFollowers = from follower in Followers
                                    where follower.ProfileId == userprofiles.Id
                                    select follower;

                UserFollowers = userFollowers.ToList();

                DateTime today = DateTime.Now;
                DateTime joinedDate = users.Date_joined;

                var accountTenure = today - joinedDate;

                AccountTenure = accountTenure.Days;


            }
            return Page();
        }
    }
}
