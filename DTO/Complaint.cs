
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Complaint 
    {
        public int Id { get; set; }
        public int? SubscriberId { get; set; }

        public string? NationalNumber { get; set; }

        public string? IronNumber { get; set; }

        public string? Email { get; set; }

        public string? CallerName { get; set; }

        public string? Address { get; set; }

        public DateTime? MalfunctionDate { get; set; }

        public string? EstimatedValue { get; set; }
        public string? ComplaintDetails { get; set; }

        public int? CityId { get; set; }

        public int? AreaId { get; set; }

        public int? ComplaintStatusId { get; set; }

        public int? ComplaintSourceId { get; set; }

        public int? ComplaintTypeId { get; set; }

        public int? RequestId { get; set; }

        public int? CreationUserId { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? ModifyUserId { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? DeleteUserId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeleteDate { get; set; }

        public string? ComplaintNo { get; set; }
        public int? ComplainingpartiesId { get; set; }
        public int? ComplaintMethodId { get; set; }
        public string? Mobile { get; set; }
        public string? Fax { get; set; }
        public string? Phone { get; set; }
        public int? OfficialComplainingPartiesId { get; set; }
        public string? ComplaintBookNumber { get; set; }
        public DateTime? ComplaintBookDate { get; set; }
        public virtual Lookup? ComplaintMethod { get; set; }

        public virtual Lookup? ComplaintMethods { get; set; }

        public virtual Lookup? Area { get; set; }

        public virtual Lookup? City { get; set; }

        public virtual Lookup? Complainingparties { get; set; }

        public virtual Lookup? ComplaintSource { get; set; }

        public virtual Lookup? ComplaintStatus { get; set; }

        public virtual ComplaintType? ComplaintType { get; set; }

        public virtual User? CreationUser { get; set; }

        public virtual User? DeleteUser { get; set; }

        public virtual User? ModifyUser { get; set; }
        public virtual Lookup? OfficialComplainingParties { get; set; }

        public virtual GeneralRequest? Request { get; set; }

        public virtual Subscriber? Subscriber { get; set; }
    }
}
