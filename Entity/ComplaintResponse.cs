using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("ComplaintResponse")]
    public partial class ComplaintResponse : BaseGet
    {

        [Column(TypeName = "datetime")]
        public DateTime? ResponseTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ResponseDate { get; set; }
        [StringLength(10)]
        public string? ReplyBookNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExportDate { get; set; }
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
        [Column("ComplaintStatusID")]
        public int? ComplaintStatusId { get; set; }
        [Column("ExportOfficeID")]
        public int? ExportOfficeId { get; set; }
        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }
        public string? ReplyBookTopic { get; set; }
        public string? TextResponse { get; set; }
        [Column("RequestID")]
        public int? RequestId { get; set; }

        [ForeignKey("ComplaintStatusId")]
        [InverseProperty("ComplaintResponseComplaintStatuses")]
        public virtual Lookup? ComplaintStatus { get; set; }
        [ForeignKey("CreationUserId")]
        [InverseProperty("ComplaintResponseCreationUsers")]
        public virtual User? CreationUser { get; set; }
        [ForeignKey("DeleteUserId")]
        [InverseProperty("ComplaintResponseDeleteUsers")]
        public virtual User? DeleteUser { get; set; }
        [ForeignKey("EmployeeId")]
        [InverseProperty("ComplaintResponses")]
        public virtual Employee? Employee { get; set; }
        [ForeignKey("ExportOfficeId")]
        [InverseProperty("ComplaintResponseExportOffices")]
        public virtual Lookup? ExportOffice { get; set; }
        [ForeignKey("ModifyUserId")]
        [InverseProperty("ComplaintResponseModifyUsers")]
        public virtual User? ModifyUser { get; set; }
        [ForeignKey("RequestId")]
        [InverseProperty("ComplaintResponses")]
        public virtual GeneralRequest? Request { get; set; }
    }
}
