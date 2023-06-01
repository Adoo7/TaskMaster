using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskMasterBusinessObjects
{
    [Table("proj_ProjectUser")]
    public partial class ProjProjectUser
    {
        [Key]
        [Column("projectUserID")]
        public int ProjectUserId { get; set; }
        [Column("userID")]
        public int? UserId { get; set; }
        [Column("projectID")]
        public int? ProjectId { get; set; }
        [Column("manager")]
        public bool Manager { get; set; }

        [ForeignKey("ProjectId")]
        [InverseProperty("ProjProjectUsers")]
        public virtual ProjProject? Project { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("ProjProjectUsers")]
        public virtual ProjUser? User { get; set; }
    }
}
