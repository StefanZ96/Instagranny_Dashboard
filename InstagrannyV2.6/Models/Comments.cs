using System.ComponentModel.DataAnnotations.Schema;

namespace InstagrannyV2.Models
{
    [Table("core_comments")]
    public class Comments
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("comm_text")]
        public string? commentText { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("Id")]
        public virtual Users Users { get; set; }

        [Column("creator_id")]
        public int creatorId { get; set; }

        [Column("post_id")]
        public int postId { get; set; }

    }
}
