using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("Employee")]
    public partial class Employee : BaseGet
    {
        public Employee()
        {
            Audits = new HashSet<Audit>();
            ComplaintResponses = new HashSet<ComplaintResponse>();
        }

        [Column("DepartmentID")]
        public int? DepartmentId { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
        [StringLength(100)]
        public string? NameArabic { get; set; }
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
        [Column("RequestID")]
        public int? RequestId { get; set; }
        [Column("ComplainingPartiesID")]
        public int? ComplainingPartiesId { get; set; }
        [Column("BranchID")]
        public int? BranchId { get; set; }
        [Column("LookupTypeID")]
        public int? LookupTypeId { get; set; }

        [ForeignKey("BranchId")]
        [InverseProperty("EmployeeBranches")]
        public virtual Lookup? Branch { get; set; }
        [ForeignKey("ComplainingPartiesId")]
        [InverseProperty("EmployeeComplainingParties")]
        public virtual Lookup? ComplainingParties { get; set; }
        [ForeignKey("CreationUserId")]
        [InverseProperty("EmployeeCreationUsers")]
        public virtual User? CreationUser { get; set; }
        [ForeignKey("DeleteUserId")]
        [InverseProperty("EmployeeDeleteUsers")]
        public virtual User? DeleteUser { get; set; }
        [ForeignKey("DepartmentId")]
        [InverseProperty("EmployeeDepartments")]
        public virtual Lookup? Department { get; set; }
        [ForeignKey("ModifyUserId")]
        [InverseProperty("EmployeeModifyUsers")]
        public virtual User? ModifyUser { get; set; }
        [ForeignKey("RequestId")]
        [InverseProperty("Employees")]
        public virtual GeneralRequest? Request { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<Audit> Audits { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<ComplaintResponse> ComplaintResponses { get; set; }
    }
}
