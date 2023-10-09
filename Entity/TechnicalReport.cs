using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("TechnicalReport")]
    public partial class TechnicalReport : BaseGet
    {

        [Column("ReportNO")]
        [StringLength(10)]
        public string? ReportNo { get; set; }
        [StringLength(10)]
        public string? SubjectReport { get; set; }
        public string? ReportText { get; set; }

        [Column("CreationUserID")]
        public int? CreationUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }
        [Column("ModifyUserID")]
        public int? ModifyUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }
        [Column("DeleteUserID")]
        public int? DeleteUserId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DeleteDate { get; set; }
        [Column("RequestID")]
        public int? RequestId { get; set; }

        [ForeignKey("CreationUserId")]
        [InverseProperty("TechnicalReportCreationUsers")]
        public virtual User? CreationUser { get; set; }
        [ForeignKey("DeleteUserId")]
        [InverseProperty("TechnicalReportDeleteUsers")]
        public virtual User? DeleteUser { get; set; }
        [ForeignKey("ModifyUserId")]
        [InverseProperty("TechnicalReportModifyUsers")]
        public virtual User? ModifyUser { get; set; }
        [ForeignKey("RequestId")]
        [InverseProperty("TechnicalReports")]
        public virtual GeneralRequest? Request { get; set; }
    }
}
