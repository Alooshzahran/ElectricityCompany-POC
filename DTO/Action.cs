using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Action
    {
        public int Id { get; set; }
        public string? ActionNameAr { get; set; }
        public string? ActionNameEn { get; set; }
        public string? ActionNameWorkflow { get; set; }
        public virtual ICollection<ActionHistory> ActionHistories { get; set; }
    }
}
