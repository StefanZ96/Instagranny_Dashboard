using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstagrannyV2.Models
{
    [Table("auth_user")]
    public class Users
    {
        [Column("id")]        
        public int Id { get; set; }
        

        [Column("username")]
        public string Username { get; set; }
        [Column("date_joined")]
        public DateTime Date_joined { get; set; }
        
        [Column("last_login")]
        public DateTime Last_login { get; set; }

        public virtual Profiles Profiles { get; set; }

        public ICollection<Posts> Posts { get; set; }
        public ICollection<Comments> Comments { get; set; }

        public static implicit operator Users(IdentityUserClaim<string> v)
        {
            throw new NotImplementedException();
        }
    }
}
