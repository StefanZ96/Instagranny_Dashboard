using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstagrannyV2.Models
{
    [Table("auth_user")]
    public class Login
    {
        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("is_superuser")]
        public bool isSuperuser { get; set; }
    }
}
