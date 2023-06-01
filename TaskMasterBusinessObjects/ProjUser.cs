using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskMasterBusinessObjects
{
    [Table("proj_User")]
    public partial class ProjUser
    {
        public ProjUser()
        {
            ProjActionLogs = new HashSet<ProjActionLog>();
            ProjComments = new HashSet<ProjComment>();
            ProjDocuments = new HashSet<ProjDocument>();
            ProjExceptionLogs = new HashSet<ProjExceptionLog>();
            ProjNotifications = new HashSet<ProjNotification>();
            ProjProjectUsers = new HashSet<ProjProjectUser>();
            ProjTasks = new HashSet<ProjTask>();
        }

        [Key]
        [Column("userID")]
        public int UserId { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; } = null!;
        [Column("pass")]
        [StringLength(50)]
        public string Pass { get; set; } = null!;

        [InverseProperty("User")]
        public virtual ICollection<ProjActionLog> ProjActionLogs { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ProjComment> ProjComments { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ProjDocument> ProjDocuments { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ProjExceptionLog> ProjExceptionLogs { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ProjNotification> ProjNotifications { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ProjProjectUser> ProjProjectUsers { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ProjTask> ProjTasks { get; set; }
    }
}
