
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Employee 
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }

        public int? DepartmentId { get; set; }

        public string? Name { get; set; }

        public string? NameArabic { get; set; }

        public int? CreationUserId { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? ModifyUserId { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? DeleteUserId { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? RequestId { get; set; }

        public int? ComplainingPartiesId { get; set; }
        public int? BranchId { get; set; }
        public int? LookupTypeId { get; set; }
        public virtual Lookup? Branch { get; set; }
        public virtual Lookup? ComplainingParties { get; set; }
        public virtual User? CreationUser { get; set; }

        public virtual User? DeleteUser { get; set; }
 
        public virtual Lookup? Department { get; set; }
 
        public virtual User? ModifyUser { get; set; }
 
        public virtual GeneralRequest? Request { get; set; }

        public virtual ICollection<Audit> Audits { get; set; }

        public virtual ICollection<ComplaintResponse> ComplaintResponses { get; set; }
    }
}
