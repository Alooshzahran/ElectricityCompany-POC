using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TechnicalReport 
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }

        public string? ReportNo { get; set; }
        public string? SubjectReport { get; set; }
        public string? ReportText { get; set; }

        public int? CreationUserId { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? ModifyUserId { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? DeleteUserId { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? RequestId { get; set; }


        public virtual User? CreationUser { get; set; }

        public virtual User? DeleteUser { get; set; }

        public virtual User? ModifyUser { get; set; }

        public virtual GeneralRequest? Request { get; set; }
    }
}
