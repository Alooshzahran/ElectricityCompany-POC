using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("ActionHistory")]
    public partial class ActionHistory
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("RequestID")]
        public int? RequestId { get; set; }
        [Column("ActionID")]
        public int? ActionId { get; set; }
        public string? Remark { get; set; }
        [Column("StepID")]
        public int? StepId { get; set; }
        [StringLength(100)]
        public string? ActionName { get; set; }
        [StringLength(100)]
        public string? ActionByUserName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ActionDateTime { get; set; }
        [StringLength(50)]
        public string? UserActionGroup { get; set; }

        [ForeignKey("ActionId")]
        [InverseProperty("ActionHistories")]
        public virtual Action? Action { get; set; }
        [ForeignKey("RequestId")]
        [InverseProperty("ActionHistories")]
        public virtual GeneralRequest? Request { get; set; }
        [ForeignKey("StepId")]
        [InverseProperty("ActionHistories")]
        public virtual GeneralStep? Step { get; set; }
    }
}
