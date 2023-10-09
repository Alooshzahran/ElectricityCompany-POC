using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LookupType
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }

        public string? Name { get; set; }

        public string? NameArabic { get; set; }

        public string? Code { get; set; }

        public int? CreationUserId { get; set; }

        public DateTime? CreationDate { get; set; }
        public int? ModifyUserId { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? DeleteUserId { get; set; }

        public DateTime? DeleteDate { get; set; }
        public virtual ICollection<Lookup> LookupLookupTypes { get; set; }
        public virtual ICollection<Lookup> LookupParents { get; set; }

    }
}
