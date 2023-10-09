using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public partial class User : BaseGet
    {
        public User()
        {
            AttachmentCreationUsers = new HashSet<Attachment>();
            AttachmentDeleteUsers = new HashSet<Attachment>();
            AttachmentModifyUsers = new HashSet<Attachment>();
            AuditCreationUsers = new HashSet<Audit>();
            AuditDeleteUsers = new HashSet<Audit>();
            AuditModifyUsers = new HashSet<Audit>();
            ComplaintCategoryCreationUsers = new HashSet<ComplaintCategory>();
            ComplaintCategoryDeleteUsers = new HashSet<ComplaintCategory>();
            ComplaintCategoryModifyUsers = new HashSet<ComplaintCategory>();
            ComplaintCreationUsers = new HashSet<Complaint>();
            ComplaintDeleteUsers = new HashSet<Complaint>();
            ComplaintModifyUsers = new HashSet<Complaint>();
            ComplaintResponseCreationUsers = new HashSet<ComplaintResponse>();
            ComplaintResponseDeleteUsers = new HashSet<ComplaintResponse>();
            ComplaintResponseModifyUsers = new HashSet<ComplaintResponse>();
            ComplaintTypeCreationUsers = new HashSet<ComplaintType>();
            ComplaintTypeDeleteUsers = new HashSet<ComplaintType>();
            ComplaintTypeModifyUsers = new HashSet<ComplaintType>();
            EmployeeCreationUsers = new HashSet<Employee>();
            EmployeeDeleteUsers = new HashSet<Employee>();
            EmployeeModifyUsers = new HashSet<Employee>();
            SubscriberCreationUsers = new HashSet<Subscriber>();
            SubscriberDeleteUsers = new HashSet<Subscriber>();
            SubscriberModifyUsers = new HashSet<Subscriber>();
            TechnicalReportCreationUsers = new HashSet<TechnicalReport>();
            TechnicalReportDeleteUsers = new HashSet<TechnicalReport>();
            TechnicalReportModifyUsers = new HashSet<TechnicalReport>();
        }


        [StringLength(50)]
        public string? EmployeeName { get; set; }
        [Column("DepartmentID")]
        public int? DepartmentId { get; set; }
        [Column("BranchID")]
        public int? BranchId { get; set; }
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
        [Column("ComplaintMethodID")]
        public int? ComplaintMethodId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ComplaintDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [StringLength(10)]
        public string? Mobile { get; set; }
        [StringLength(10)]
        public string? Phone { get; set; }
        [StringLength(10)]
        public string? Fax { get; set; }
        [Column("ComplainingPartiesID")]
        public int? ComplainingPartiesId { get; set; }

        [InverseProperty("CreationUser")]
        public virtual ICollection<Attachment> AttachmentCreationUsers { get; set; }
        [InverseProperty("DeleteUser")]
        public virtual ICollection<Attachment> AttachmentDeleteUsers { get; set; }
        [InverseProperty("ModifyUser")]
        public virtual ICollection<Attachment> AttachmentModifyUsers { get; set; }
        [InverseProperty("CreationUser")]
        public virtual ICollection<Audit> AuditCreationUsers { get; set; }
        [InverseProperty("DeleteUser")]
        public virtual ICollection<Audit> AuditDeleteUsers { get; set; }
        [InverseProperty("ModifyUser")]
        public virtual ICollection<Audit> AuditModifyUsers { get; set; }
        [InverseProperty("CreationUser")]
        public virtual ICollection<ComplaintCategory> ComplaintCategoryCreationUsers { get; set; }
        [InverseProperty("DeleteUser")]
        public virtual ICollection<ComplaintCategory> ComplaintCategoryDeleteUsers { get; set; }
        [InverseProperty("ModifyUser")]
        public virtual ICollection<ComplaintCategory> ComplaintCategoryModifyUsers { get; set; }
        [InverseProperty("CreationUser")]
        public virtual ICollection<Complaint> ComplaintCreationUsers { get; set; }
        [InverseProperty("DeleteUser")]
        public virtual ICollection<Complaint> ComplaintDeleteUsers { get; set; }
        [InverseProperty("ModifyUser")]
        public virtual ICollection<Complaint> ComplaintModifyUsers { get; set; }
        [InverseProperty("CreationUser")]
        public virtual ICollection<ComplaintResponse> ComplaintResponseCreationUsers { get; set; }
        [InverseProperty("DeleteUser")]
        public virtual ICollection<ComplaintResponse> ComplaintResponseDeleteUsers { get; set; }
        [InverseProperty("ModifyUser")]
        public virtual ICollection<ComplaintResponse> ComplaintResponseModifyUsers { get; set; }
        [InverseProperty("CreationUser")]
        public virtual ICollection<ComplaintType> ComplaintTypeCreationUsers { get; set; }
        [InverseProperty("DeleteUser")]
        public virtual ICollection<ComplaintType> ComplaintTypeDeleteUsers { get; set; }
        [InverseProperty("ModifyUser")]
        public virtual ICollection<ComplaintType> ComplaintTypeModifyUsers { get; set; }
        [InverseProperty("CreationUser")]
        public virtual ICollection<Employee> EmployeeCreationUsers { get; set; }
        [InverseProperty("DeleteUser")]
        public virtual ICollection<Employee> EmployeeDeleteUsers { get; set; }
        [InverseProperty("ModifyUser")]
        public virtual ICollection<Employee> EmployeeModifyUsers { get; set; }
        [InverseProperty("CreationUser")]
        public virtual ICollection<Subscriber> SubscriberCreationUsers { get; set; }
        [InverseProperty("DeleteUser")]
        public virtual ICollection<Subscriber> SubscriberDeleteUsers { get; set; }
        [InverseProperty("ModifyUser")]
        public virtual ICollection<Subscriber> SubscriberModifyUsers { get; set; }
        [InverseProperty("CreationUser")]
        public virtual ICollection<TechnicalReport> TechnicalReportCreationUsers { get; set; }
        [InverseProperty("DeleteUser")]
        public virtual ICollection<TechnicalReport> TechnicalReportDeleteUsers { get; set; }
        [InverseProperty("ModifyUser")]
        public virtual ICollection<TechnicalReport> TechnicalReportModifyUsers { get; set; }
    }
}
