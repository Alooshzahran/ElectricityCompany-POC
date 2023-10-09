using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("Complaint")]
    public partial class Complaint : BaseGet
    {

        [Column("SubscriberID")]
        public int? SubscriberId { get; set; }
        [StringLength(20)]
        public string? NationalNumber { get; set; }
        [StringLength(20)]
        public string? IronNumber { get; set; }
        [StringLength(30)]
        public string? Email { get; set; }
        [StringLength(50)]
        public string? CallerName { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? MalfunctionDate { get; set; }
        [StringLength(50)]
        public string? EstimatedValue { get; set; }
        public string? ComplaintDetails { get; set; }
        [Column("CityID")]
        public int? CityId { get; set; }
        [Column("AreaID")]
        public int? AreaId { get; set; }
        [Column("ComplaintStatusID")]
        public int? ComplaintStatusId { get; set; }
        [Column("ComplaintSourceID")]
        public int? ComplaintSourceId { get; set; }
        [Column("ComplaintTypeID")]
        public int? ComplaintTypeId { get; set; }
        [Column("RequestID")]
        public int? RequestId { get; set; }
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
        [Column("ComplaintNO")]
        [StringLength(20)]
        public string? ComplaintNo { get; set; }
        [Column("ComplainingpartiesID")]
        public int? ComplainingpartiesId { get; set; }
        [Column("ComplaintMethodID")]
        public int? ComplaintMethodId { get; set; }
        [StringLength(35)]
        public string? Mobile { get; set; }
        [StringLength(35)]
        public string? Fax { get; set; }
        [StringLength(35)]
        public string? Phone { get; set; }
        [Column("OfficialComplainingPartiesID")]
        public int? OfficialComplainingPartiesId { get; set; }
        [StringLength(35)]
        public string? ComplaintBookNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ComplaintBookDate { get; set; }

        [ForeignKey("AreaId")]
        [InverseProperty("ComplaintAreas")]
        public virtual Lookup? Area { get; set; }
        [ForeignKey("CityId")]
        [InverseProperty("ComplaintCities")]
        public virtual Lookup? City { get; set; }
        [ForeignKey("ComplainingpartiesId")]
        [InverseProperty("ComplaintComplainingparties")]
        public virtual Lookup? Complainingparties { get; set; }
        [ForeignKey("ComplaintMethodId")]
        [InverseProperty("ComplaintComplaintMethods")]
        public virtual Lookup? ComplaintMethod { get; set; }
        [ForeignKey("ComplaintSourceId")]
        [InverseProperty("ComplaintComplaintSources")]
        public virtual Lookup? ComplaintSource { get; set; }
        [ForeignKey("ComplaintStatusId")]
        [InverseProperty("ComplaintComplaintStatuses")]
        public virtual Lookup? ComplaintStatus { get; set; }
        [ForeignKey("ComplaintTypeId")]
        [InverseProperty("Complaints")]
        public virtual ComplaintType? ComplaintType { get; set; }
        [ForeignKey("CreationUserId")]
        [InverseProperty("ComplaintCreationUsers")]
        public virtual User? CreationUser { get; set; }
        [ForeignKey("DeleteUserId")]
        [InverseProperty("ComplaintDeleteUsers")]
        public virtual User? DeleteUser { get; set; }
        [ForeignKey("ModifyUserId")]
        [InverseProperty("ComplaintModifyUsers")]
        public virtual User? ModifyUser { get; set; }
        [ForeignKey("OfficialComplainingPartiesId")]
        [InverseProperty("ComplaintOfficialComplainingParties")]
        public virtual Lookup? OfficialComplainingParties { get; set; }
        [ForeignKey("RequestId")]
        [InverseProperty("Complaints")]
        public virtual GeneralRequest? Request { get; set; }
        [ForeignKey("SubscriberId")]
        [InverseProperty("Complaints")]
        public virtual Subscriber? Subscriber { get; set; }
    }
}
