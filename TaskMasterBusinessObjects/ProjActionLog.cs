using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskMasterBusinessObjects
{
    [Table("proj_ActionLogs")]
    public partial class ProjActionLog
    {
        [Key]
        [Column("logID")]
        public int LogId { get; set; }
        [Column("source")]
        [StringLength(50)]
        public string Source { get; set; } = null!;
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
        [Column("message")]
        [StringLength(50)]
        public string Message { get; set; } = null!;
        [Column("originalValue")]
        [StringLength(50)]
        public string OriginalValue { get; set; } = null!;
        [Column("currentValue")]
        [StringLength(50)]
        public string CurrentValue { get; set; } = null!;
        [Column("userID")]
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("ProjActionLogs")]
        public virtual ProjUser? User { get; set; }
    }
}
