using System.ComponentModel.DataAnnotations.Schema;


namespace InstagrannyV2.Models
{
    [Table("core_profile")]
    public class Profiles
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("bio")]
        public string Bio { get; set; }

        [Column("profileimg")]
        public string ProfilePhotoUrl { get; set; }

        [ForeignKey("Id")]
        
        public virtual Users Users { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
    }
}
