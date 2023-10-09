using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ComplaintType 
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }

        public string? Name { get; set; }

        public string? DaysNo { get; set; }

        public int? ComplaintCategoryId { get; set; }
        public int? CreationUserId { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? ModifyUserId { get; set; }
  
        public DateTime? ModifyDate { get; set; }

        public int? DeleteUserId { get; set; }

        public DateTime? DeleteDate { get; set; }

        public virtual ComplaintCategory? ComplaintCategory { get; set; }

        public virtual User? CreationUser { get; set; }
 
        public virtual User? DeleteUser { get; set; }

        public virtual User? ModifyUser { get; set; }

        public virtual ICollection<Complaint> Complaints { get; set; }
    }
}
