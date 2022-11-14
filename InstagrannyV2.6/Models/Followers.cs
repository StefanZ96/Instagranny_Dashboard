using System.ComponentModel.DataAnnotations.Schema;

namespace InstagrannyV2.Models
{
    [Table("core_profile_followers")]
    public class Followers
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("profile_id")]
        [ForeignKey("Id")]
        public int ProfileId { get; set; }

        [Column("user_id")]
        [ForeignKey("Id")]
        public int UserId { get; set; }


    }
}
