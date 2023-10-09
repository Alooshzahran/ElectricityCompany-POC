using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ActionHistory
    {

        public int Id { get; set; }

        public int? RequestId { get; set; }

        public int? ActionId { get; set; }
        public string? Remark { get; set; }

        public int? StepId { get; set; }

        public string? ActionName { get; set; }

        public string? ActionByUserName { get; set; }

        public DateTime? ActionDateTime { get; set; }

        public string? UserActionGroup { get; set; }


        public virtual Action? Action { get; set; }

        public virtual GeneralRequest? Request { get; set; }

        public virtual GeneralStep? Step { get; set; }
    }
}
