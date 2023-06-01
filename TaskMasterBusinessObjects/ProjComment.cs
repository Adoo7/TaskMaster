using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskMasterBusinessObjects
{
    [Table("proj_Comment")]
    public partial class ProjComment
    {
        [Key]
        [Column("commentID")]
        public int CommentId { get; set; }
        [Column("commentDate", TypeName = "date")]
        public DateTime CommentDate { get; set; }
        [Column("commentText")]
        [StringLength(50)]
        public string CommentText { get; set; } = null!;
        [Column("userID")]
        public int? UserId { get; set; }
        [Column("taskID")]
        public int? TaskId { get; set; }

        [ForeignKey("TaskId")]
        [InverseProperty("ProjComments")]
        public virtual ProjTask? Task { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("ProjComments")]
        public virtual ProjUser? User { get; set; }
    }
}
