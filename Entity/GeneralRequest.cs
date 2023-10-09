using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("general_requests")]
    public partial class GeneralRequest
    {
        public GeneralRequest()
        {
            ActionHistories = new HashSet<ActionHistory>();
            Attachments = new HashSet<Attachment>();
            ComplaintResponses = new HashSet<ComplaintResponse>();
            Complaints = new HashSet<Complaint>();
            Employees = new HashSet<Employee>();
            Subscribers = new HashSet<Subscriber>();
            TechnicalReports = new HashSet<TechnicalReport>();
        }

        [Key]
        [Column("RequestID")]
        public int RequestId { get; set; }
        public int? RequestNo { get; set; }
        [StringLength(11)]
        public string? EmpNumber { get; set; }
        [StringLength(200)]
        public string? EmpFullNameAr { get; set; }
        [StringLength(200)]
        public string? EmpFullNameEn { get; set; }
        [StringLength(100)]
        public string? EmpUserName { get; set; }
        [Column("ServiceTypeID")]
        public int? ServiceTypeId { get; set; }
        [Column("StepID")]
        public int? StepId { get; set; }
        [Column("StatusID")]
        [StringLength(30)]
        public string? StatusId { get; set; }
        [Column("ProcessID")]
        public long? ProcessId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ActionLastDateTime { get; set; }
        public bool? OnBehalf { get; set; }
        [StringLength(100)]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDateTime { get; set; }

        [ForeignKey("ServiceTypeId")]
        [InverseProperty("GeneralRequests")]
        public virtual GeneralServiceType? ServiceType { get; set; }
        [ForeignKey("StepId")]
        [InverseProperty("GeneralRequests")]
        public virtual GeneralStep? Step { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<ActionHistory> ActionHistories { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<Attachment> Attachments { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<ComplaintResponse> ComplaintResponses { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<Complaint> Complaints { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<Employee> Employees { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<Subscriber> Subscribers { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<TechnicalReport> TechnicalReports { get; set; }
    }
}
