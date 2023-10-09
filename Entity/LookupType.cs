using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("LookupType")]
    public partial class LookupType : BaseGet
    {
        public LookupType()
        {
            LookupLookupTypes = new HashSet<Lookup>();
            LookupParents = new HashSet<Lookup>();
        }


        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? NameArabic { get; set; }
        [StringLength(50)]
        public string? Code { get; set; }
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
        [Column(TypeName = "datetime")]
        public DateTime? DeleteDate { get; set; }

        [InverseProperty("LookupType")]
        public virtual ICollection<Lookup> LookupLookupTypes { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<Lookup> LookupParents { get; set; }
    }
}
