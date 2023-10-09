using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("general_serviceType")]
    public partial class GeneralServiceType
    {
        public GeneralServiceType()
        {
            GeneralRequests = new HashSet<GeneralRequest>();
        }

        [Key]
        [Column("STID")]
        public int Stid { get; set; }
        [StringLength(200)]
        public string? ServiceTypeEn { get; set; }
        [Column("ServiceTypeAR")]
        [StringLength(200)]
        public string? ServiceTypeAr { get; set; }
        public int? Ordering { get; set; }
        public bool? Enabled { get; set; }
        [Column("ServiceID")]
        public int? ServiceId { get; set; }
        [Column("ERPCode")]
        [StringLength(100)]
        public string? Erpcode { get; set; }

        [ForeignKey("ServiceId")]
        [InverseProperty("GeneralServiceTypes")]
        public virtual Service? Service { get; set; }
        [InverseProperty("ServiceType")]
        public virtual ICollection<GeneralRequest> GeneralRequests { get; set; }
    }
}
