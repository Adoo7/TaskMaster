using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskMasterBusinessObjects
{
    [Table("proj_Status")]
    public partial class ProjStatus
    {
        public ProjStatus()
        {
            ProjTasks = new HashSet<ProjTask>();
        }

        [Key]
        [Column("statusID")]
        public int StatusId { get; set; }
        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; } = null!;

        [InverseProperty("Status")]
        public virtual ICollection<ProjTask> ProjTasks { get; set; }
    }
}
