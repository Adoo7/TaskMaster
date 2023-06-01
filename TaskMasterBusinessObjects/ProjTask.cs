using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskMasterBusinessObjects
{
    [Table("proj_Task")]
    public partial class ProjTask
    {
        public ProjTask()
        {
            ProjComments = new HashSet<ProjComment>();
            ProjDocuments = new HashSet<ProjDocument>();
        }

        [Key]
        [Column("taskID")]
        public int TaskId { get; set; }
        [Column("taskName")]
        [StringLength(50)]
        public string TaskName { get; set; } = null!;
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; } = null!;
        [Column("deadline", TypeName = "date")]
        public DateTime Deadline { get; set; }
        [Column("userID")]
        public int? UserId { get; set; }
        [Column("statusID")]
        public int? StatusId { get; set; }
        [Column("projectID")]
        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        [InverseProperty("ProjTasks")]
        public virtual ProjProject? Project { get; set; }
        [ForeignKey("StatusId")]
        [InverseProperty("ProjTasks")]
        public virtual ProjStatus? Status { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("ProjTasks")]
        public virtual ProjUser? User { get; set; }
        [InverseProperty("Task")]
        public virtual ICollection<ProjComment> ProjComments { get; set; }
        [InverseProperty("Task")]
        public virtual ICollection<ProjDocument> ProjDocuments { get; set; }
    }
}
