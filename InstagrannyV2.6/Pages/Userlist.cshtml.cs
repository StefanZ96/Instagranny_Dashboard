using InstagrannyV2._6.Areas.Identity.Data;
using InstagrannyV2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;

namespace InstagrannyV2.Pages
{
    public class UserlistModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UserlistModel(ApplicationDbContext context)
        {
            _context = context;
        }



        public List<Users> Users = new List<Users>();
        public List<Followers> Followers = new List<Followers>();
        public Hashtable Followings = new Hashtable();
        public Hashtable uFollowers = new Hashtable();
        
        public void OnGet()
        {
            Users = _context.Users.ToList();
            Followers = _context.Followers.ToList();

            foreach (var user in Users)
            {
                var userFollowings = from follower in Followers
                                     where follower.UserId == user.Id
                                     select follower;
                
                int followingNumber = userFollowings.Count();
                
                Followings.Add(user, followingNumber);

                var userprofile = _context.Profiles.FirstOrDefault(p => p.UserId == user.Id);

                var userFollowers = from follower in Followers
                                    where follower.ProfileId == userprofile.Id
                                    select follower;

                int followerNumber = userFollowers.Count();

                uFollowers.Add(user.Id, followerNumber);

            }
        
        }
    }
}
