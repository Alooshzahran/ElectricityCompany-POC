using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GeneralRequest
    {

        public int RequestId { get; set; }
        public int? RequestNo { get; set; }
        public string? EmpNumber { get; set; }

        public string? EmpFullNameAr { get; set; }

        public string? EmpFullNameEn { get; set; }

        public string? EmpUserName { get; set; }

        public int? ServiceTypeId { get; set; }

        public int? StepId { get; set; }

        public string? StatusId { get; set; }
 
        public bool? ProcessId { get; set; }

        public DateTime? ActionLastDateTime { get; set; }
        public bool? OnBehalf { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public virtual GeneralServiceType? ServiceType { get; set; }

        public virtual GeneralStep? Step { get; set; }

        public virtual ICollection<ActionHistory> ActionHistories { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }

        public virtual ICollection<ComplaintResponse> ComplaintResponses { get; set; }

        public virtual ICollection<Complaint> Complaints { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Subscriber> Subscribers { get; set; }

        public virtual ICollection<TechnicalReport> TechnicalReports { get; set; }

    }
}
