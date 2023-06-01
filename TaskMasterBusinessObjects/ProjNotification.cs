using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskMasterBusinessObjects
{
    [Table("proj_Notification")]
    public partial class ProjNotification
    {
        [Key]
        [Column("notifID")]
        public int NotifId { get; set; }
        [Column("message")]
        [StringLength(50)]
        public string Message { get; set; } = null!;
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; } = null!;
        [Column("isRead")]
        public bool IsRead { get; set; }
        [Column("userID")]
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("ProjNotifications")]
        public virtual ProjUser? User { get; set; }
    }
}
