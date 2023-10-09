using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("Audit")]
    public partial class Audit : BaseGet
    {

        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AuditDate { get; set; }
        [Column("AuditStatusID")]
        public int? AuditStatusId { get; set; }
        public string? AuditRemark { get; set; }

        [Column("CreationUserID")]
        public int? CreationUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }
        [Column("ModifyUserID")]
        public int? ModifyUserId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifyDate { get; set; }
        [Column("DeleteUserID")]
        public int? DeleteUserId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DeleteDate { get; set; }
        [Column("RequestID")]
        public int? RequestId { get; set; }

        [ForeignKey("CreationUserId")]
        [InverseProperty("AuditCreationUsers")]
        public virtual User? CreationUser { get; set; }
        [ForeignKey("DeleteUserId")]
        [InverseProperty("AuditDeleteUsers")]
        public virtual User? DeleteUser { get; set; }
        [ForeignKey("EmployeeId")]
        [InverseProperty("Audits")]
        public virtual Employee? Employee { get; set; }
        [ForeignKey("ModifyUserId")]
        [InverseProperty("AuditModifyUsers")]
        public virtual User? ModifyUser { get; set; }
    }
}
