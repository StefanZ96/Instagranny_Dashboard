using System.ComponentModel.DataAnnotations.Schema;

namespace InstagrannyV2.Models
{

    [Table("core_post")]
    public class Posts
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("photo")]

        public string? ImageUrl { get; set; }

        [Column("description")]

        public string? Description { get; set; }

        [Column("created_at")]

        public DateTime? CreatedAt { get; set; }

        [ForeignKey("Id")]
        public virtual Users Users { get; set; }

        
        
        [Column("creator_id")]
        public int creatorId { get; set; }


    }
}
