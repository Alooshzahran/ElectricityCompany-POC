using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("Action")]
    public partial class Action
    {
        public Action()
        {
            ActionHistories = new HashSet<ActionHistory>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string? ActionNameAr { get; set; }
        [Column("ActionNameEN")]
        [StringLength(50)]
        [Unicode(false)]
        public string? ActionNameEn { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? ActionNameWorkflow { get; set; }

        [InverseProperty("Action")]
        public virtual ICollection<ActionHistory> ActionHistories { get; set; }
    }
}
