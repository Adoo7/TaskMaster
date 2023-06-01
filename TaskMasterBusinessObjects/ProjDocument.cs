using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskMasterBusinessObjects
{
    [Table("proj_Document")]
    public partial class ProjDocument
    {
        [Key]
        [Column("documentID")]
        public int DocumentId { get; set; }
        [Column("documentName")]
        [StringLength(50)]
        public string DocumentName { get; set; } = null!;
        [Column("uploadDate", TypeName = "date")]
        public DateTime UploadDate { get; set; }
        [Column("documentType")]
        [StringLength(50)]
        public string DocumentType { get; set; } = null!;
        [Column("path")]
        [StringLength(50)]
        public string Path { get; set; } = null!;
        [Column("taskID")]
        public int? TaskId { get; set; }
        [Column("userID")]
        public int? UserId { get; set; }

        [ForeignKey("TaskId")]
        [InverseProperty("ProjDocuments")]
        public virtual ProjTask? Task { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("ProjDocuments")]
        public virtual ProjUser? User { get; set; }
    }
}
