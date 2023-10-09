using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User 
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }

        public string? EmployeeName { get; set; }

        public int? DepartmentId { get; set; }

        public int? BranchId { get; set; }

        public int? RequestId { get; set; }

        public int? CreationUserId { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? ModifyUserId { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? DeleteUserId { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? ComplaintMethodId { get; set; }

        public DateTime? ComplaintDate { get; set; }

        public DateTime? CreateDate { get; set; }

        public string? Mobile { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }

        public int? ComplainingPartiesId { get; set; }


    

        public virtual ICollection<Attachment> AttachmentCreationUsers { get; set; }

        public virtual ICollection<Attachment> AttachmentDeleteUsers { get; set; }

        public virtual ICollection<Attachment> AttachmentModifyUsers { get; set; }

        public virtual ICollection<Audit> AuditCreationUsers { get; set; }

        public virtual ICollection<Audit> AuditDeleteUsers { get; set; }
    
        public virtual ICollection<Audit> AuditModifyUsers { get; set; }
   
        public virtual ICollection<ComplaintCategory> ComplaintCategoryCreationUsers { get; set; }
    
        public virtual ICollection<ComplaintCategory> ComplaintCategoryDeleteUsers { get; set; }
     
        public virtual ICollection<ComplaintCategory> ComplaintCategoryModifyUsers { get; set; }
     
        public virtual ICollection<Complaint> ComplaintCreationUsers { get; set; }

        public virtual ICollection<Complaint> ComplaintDeleteUsers { get; set; }
    
        public virtual ICollection<Complaint> ComplaintModifyUsers { get; set; }
    
        public virtual ICollection<ComplaintResponse> ComplaintResponseCreationUsers { get; set; }
   
        public virtual ICollection<ComplaintResponse> ComplaintResponseDeleteUsers { get; set; }
    
        public virtual ICollection<ComplaintResponse> ComplaintResponseModifyUsers { get; set; }
   
        public virtual ICollection<ComplaintType> ComplaintTypeCreationUsers { get; set; }
     
        public virtual ICollection<ComplaintType> ComplaintTypeDeleteUsers { get; set; }
     
        public virtual ICollection<ComplaintType> ComplaintTypeModifyUsers { get; set; }
    
        public virtual ICollection<Employee> EmployeeCreationUsers { get; set; }
    
        public virtual ICollection<Employee> EmployeeDeleteUsers { get; set; }
     
        public virtual ICollection<Employee> EmployeeModifyUsers { get; set; }
    
        public virtual ICollection<Subscriber> SubscriberCreationUsers { get; set; }
    
        public virtual ICollection<Subscriber> SubscriberDeleteUsers { get; set; }
    
        public virtual ICollection<Subscriber> SubscriberModifyUsers { get; set; }
   
        public virtual ICollection<TechnicalReport> TechnicalReportCreationUsers { get; set; }
     
        public virtual ICollection<TechnicalReport> TechnicalReportDeleteUsers { get; set; }
   
        public virtual ICollection<TechnicalReport> TechnicalReportModifyUsers { get; set; }
    }
}
