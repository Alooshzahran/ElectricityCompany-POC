using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("Attachment")]
    public partial class Attachment : BaseGet
    {
        public string? Description { get; set; }
        [Column("Attachment")]
        public string? Attachment1 { get; set; }
        [StringLength(100)]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(100)]
        public string? AttachmentGroup { get; set; }
        [Column("RequestID")]
        public int? RequestId { get; set; }
        [Column("CreationUserID")]
        public int? CreationUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }
        [Column("ModifyUserID")]
        public int? ModifyUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }
        [Column("DeleteUserID")]
        public int? DeleteUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeleteDate { get; set; }

        [ForeignKey("CreationUserId")]
        [InverseProperty("AttachmentCreationUsers")]
        public virtual User? CreationUser { get; set; }
        [ForeignKey("DeleteUserId")]
        [InverseProperty("AttachmentDeleteUsers")]
        public virtual User? DeleteUser { get; set; }
        [ForeignKey("ModifyUserId")]
        [InverseProperty("AttachmentModifyUsers")]
        public virtual User? ModifyUser { get; set; }
        [ForeignKey("RequestId")]
        [InverseProperty("Attachments")]
        public virtual GeneralRequest? Request { get; set; }
    }
}
