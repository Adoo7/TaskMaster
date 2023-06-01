using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskMasterBusinessObjects
{
    [Table("proj_ExceptionLog")]
    public partial class ProjExceptionLog
    {
        [Key]
        [Column("logID")]
        public int LogId { get; set; }
        [Column("source")]
        [StringLength(50)]
        public string Source { get; set; } = null!;
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
        [Column("exception")]
        [StringLength(50)]
        public string Exception { get; set; } = null!;
        [Column("userID")]
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("ProjExceptionLogs")]
        public virtual ProjUser? User { get; set; }
    }
}
