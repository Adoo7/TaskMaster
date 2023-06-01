using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskMasterBusinessObjects
{
    [Table("proj_Project")]
    public partial class ProjProject
    {
        public ProjProject()
        {
            ProjProjectUsers = new HashSet<ProjProjectUser>();
            ProjTasks = new HashSet<ProjTask>();
        }

        [Key]
        [Column("projectID")]
        public int ProjectId { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Column("description")]
        [StringLength(150)]
        public string Description { get; set; } = null!;

        [InverseProperty("Project")]
        public virtual ICollection<ProjProjectUser> ProjProjectUsers { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<ProjTask> ProjTasks { get; set; }
    }
}
