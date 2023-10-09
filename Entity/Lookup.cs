using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("Lookup")]
    public partial class Lookup : BaseGet
    {
        public Lookup()
        {
            //Audits = new HashSet<Audit>();
            ComplaintAreas = new HashSet<Complaint>();
            ComplaintCities = new HashSet<Complaint>();
            ComplaintComplainingparties = new HashSet<Complaint>();
            ComplaintComplaintMethods = new HashSet<Complaint>();
            ComplaintComplaintSources = new HashSet<Complaint>();
            ComplaintComplaintStatuses = new HashSet<Complaint>();
            ComplaintOfficialComplainingParties = new HashSet<Complaint>();
            ComplaintResponseComplaintStatuses = new HashSet<ComplaintResponse>();
            ComplaintResponseExportOffices = new HashSet<ComplaintResponse>();
            EmployeeBranches = new HashSet<Employee>();
            EmployeeComplainingParties = new HashSet<Employee>();
            EmployeeDepartments = new HashSet<Employee>();
            Subscribers = new HashSet<Subscriber>();
        }


        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? NameArabic { get; set; }
        [Column("ParentID")]
        public int? ParentId { get; set; }
        [Column("LookupTypeID")]
        public int? LookupTypeId { get; set; }
     
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

        [ForeignKey("LookupTypeId")]
        [InverseProperty("LookupLookupTypes")]
        public virtual LookupType? LookupType { get; set; }
        [ForeignKey("ParentId")]
        [InverseProperty("LookupParents")]
        public virtual LookupType? Parent { get; set; }

        [InverseProperty("Area")]
        public virtual ICollection<Complaint> ComplaintAreas { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Complaint> ComplaintCities { get; set; }
        [InverseProperty("Complainingparties")]
        public virtual ICollection<Complaint> ComplaintComplainingparties { get; set; }
        [InverseProperty("ComplaintMethod")]
        public virtual ICollection<Complaint> ComplaintComplaintMethods { get; set; }
        [InverseProperty("ComplaintSource")]
        public virtual ICollection<Complaint> ComplaintComplaintSources { get; set; }
        [InverseProperty("ComplaintStatus")]
        public virtual ICollection<Complaint> ComplaintComplaintStatuses { get; set; }
        [InverseProperty("OfficialComplainingParties")]
        public virtual ICollection<Complaint> ComplaintOfficialComplainingParties { get; set; }
        [InverseProperty("ComplaintStatus")]
        public virtual ICollection<ComplaintResponse> ComplaintResponseComplaintStatuses { get; set; }
        [InverseProperty("ExportOffice")]
        public virtual ICollection<ComplaintResponse> ComplaintResponseExportOffices { get; set; }
        [InverseProperty("Branch")]
        public virtual ICollection<Employee> EmployeeBranches { get; set; }
        [InverseProperty("ComplainingParties")]
        public virtual ICollection<Employee> EmployeeComplainingParties { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Employee> EmployeeDepartments { get; set; }
        [InverseProperty("SubscriptionType")]
        public virtual ICollection<Subscriber> Subscribers { get; set; }
    }
}
