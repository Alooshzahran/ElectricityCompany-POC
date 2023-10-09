using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Subscriber
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
        public string? Name { get; set; }
        public int? SubscriptionTypeId { get; set; }

        public int? CreationUserId { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? ModifyUserId { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? DeleteUserId { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? RequestId { get; set; }


        public virtual User? CreationUser { get; set; }

        public virtual User? DeleteUser { get; set; }

        public virtual User? ModifyUser { get; set; }

        public virtual GeneralRequest? Request { get; set; }


        public virtual Lookup? SubscriptionType { get; set; }

        public virtual ICollection<Complaint> Complaints { get; set; }
    }
}
