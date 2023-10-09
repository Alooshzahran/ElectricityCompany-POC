using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GeneralStep
    {

        public int Stid { get; set; }

        public string? StepNameEn { get; set; }

        public string? StepNameAr { get; set; }
        public bool? Enabled { get; set; }
        public virtual ICollection<ActionHistory> ActionHistories { get; set; }
        public virtual ICollection<GeneralRequest> GeneralRequests { get; set; }
    }
}
