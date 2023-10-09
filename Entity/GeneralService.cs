using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("general_Services")]
    public partial class GeneralService
    {
        [Key]
        [Column("SID")]
        public int Sid { get; set; }
        [StringLength(200)]
        public string? ServiceNameEn { get; set; }
        [StringLength(200)]
        public string? ServiceNameAr { get; set; }
        [StringLength(35)]
        public string? Department { get; set; }
        public string? RequestFormUrl { get; set; }
        public string? DetailsFormUrl { get; set; }
        [Column("K2DesignerFolderName")]
        [StringLength(100)]
        public string? K2designerFolderName { get; set; }
        [Column("K2WorkflowName")]
        [StringLength(100)]
        public string? K2workflowName { get; set; }
        public bool? Enabled { get; set; }
        [StringLength(100)]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDateTime { get; set; }
        [StringLength(100)]
        public string? SecurityDetailsRoleName1 { get; set; }
        [StringLength(100)]
        public string? SecurityDetailsRoleName2 { get; set; }
        [StringLength(100)]
        public string? SecurityDetailsRoleName3 { get; set; }
    }
}
