using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("general_steps")]
    public partial class GeneralStep
    {
        public GeneralStep()
        {
            ActionHistories = new HashSet<ActionHistory>();
            GeneralRequests = new HashSet<GeneralRequest>();
        }

        [Key]
        [Column("STID")]
        public int Stid { get; set; }
        [StringLength(200)]
        public string? StepNameEn { get; set; }
        [Column("StepNameAR")]
        [StringLength(100)]
        public string? StepNameAr { get; set; }
        public bool? Enabled { get; set; }

        [InverseProperty("Step")]
        public virtual ICollection<ActionHistory> ActionHistories { get; set; }
        [InverseProperty("Step")]
        public virtual ICollection<GeneralRequest> GeneralRequests { get; set; }
    }
}
