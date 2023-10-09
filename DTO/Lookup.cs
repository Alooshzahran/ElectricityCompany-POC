
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Lookup 
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }

        public string? Name { get; set; }

        public string? NameArabic { get; set; }

        public int? ParentId { get; set; }

        public int? LookupTypeId { get; set; }

        public int? CreationUserId { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? ModifyUserId { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? DeleteUserId { get; set; }

        public DateTime? DeleteDate { get; set; }

        public virtual LookupType? LookupType { get; set; }

        public virtual LookupType? Parent { get; set; }



        public virtual ICollection<Complaint> ComplaintAreas { get; set; }

        public virtual ICollection<Complaint> ComplaintCities { get; set; }

        public virtual ICollection<Complaint> ComplaintComplainingparties { get; set; }
        public virtual ICollection<Complaint> ComplaintComplaintMethods { get; set; }
        public virtual ICollection<Complaint> ComplaintComplaintSources { get; set; }

        public virtual ICollection<Complaint> ComplaintComplaintStatuses { get; set; }
        public virtual ICollection<Complaint> ComplaintOfficialComplainingParties { get; set; }

        public virtual ICollection<ComplaintResponse> ComplaintResponseComplaintStatuses { get; set; }

        public virtual ICollection<ComplaintResponse> ComplaintResponseExportOffices { get; set; }

        public virtual ICollection<Employee> EmployeeBranches { get; set; }
        public virtual ICollection<Employee> EmployeeComplainingParties { get; set; }
        public virtual ICollection<Employee> EmployeeDepartments { get; set; }
        public virtual ICollection<Subscriber> Subscribers { get; set; }
    }
}
