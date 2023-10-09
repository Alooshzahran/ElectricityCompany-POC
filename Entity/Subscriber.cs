using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("Subscriber")]
    public partial class Subscriber : BaseGet
    {
        public Subscriber()
        {
            Complaints = new HashSet<Complaint>();
        }


        [StringLength(50)]
        public string? Name { get; set; }
        [Column("SubscriptionTypeID")]
        public int? SubscriptionTypeId { get; set; }

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
        [Column("RequestID")]
        public int? RequestId { get; set; }

        [ForeignKey("CreationUserId")]
        [InverseProperty("SubscriberCreationUsers")]
        public virtual User? CreationUser { get; set; }
        [ForeignKey("DeleteUserId")]
        [InverseProperty("SubscriberDeleteUsers")]
        public virtual User? DeleteUser { get; set; }
        [ForeignKey("ModifyUserId")]
        [InverseProperty("SubscriberModifyUsers")]
        public virtual User? ModifyUser { get; set; }
        [ForeignKey("RequestId")]
        [InverseProperty("Subscribers")]
        public virtual GeneralRequest? Request { get; set; }
        [ForeignKey("SubscriptionTypeId")]
        [InverseProperty("Subscribers")]
        public virtual Lookup? SubscriptionType { get; set; }
        [InverseProperty("Subscriber")]
        public virtual ICollection<Complaint> Complaints { get; set; }
    }
}
