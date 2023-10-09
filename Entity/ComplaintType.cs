using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("ComplaintType")]
    public partial class ComplaintType : BaseGet
    {
        public ComplaintType()
        {
            Complaints = new HashSet<Complaint>();
        }


        [StringLength(50)]
        public string? Name { get; set; }
        [Column("DaysNO")]
        [StringLength(10)]
        public string? DaysNo { get; set; }
        [Column("ComplaintCategoryID")]
        public int? ComplaintCategoryId { get; set; }
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

        [ForeignKey("ComplaintCategoryId")]
        [InverseProperty("ComplaintTypes")]
        public virtual ComplaintCategory? ComplaintCategory { get; set; }
        [ForeignKey("CreationUserId")]
        [InverseProperty("ComplaintTypeCreationUsers")]
        public virtual User? CreationUser { get; set; }
        [ForeignKey("DeleteUserId")]
        [InverseProperty("ComplaintTypeDeleteUsers")]
        public virtual User? DeleteUser { get; set; }
        [ForeignKey("ModifyUserId")]
        [InverseProperty("ComplaintTypeModifyUsers")]
        public virtual User? ModifyUser { get; set; }
        [InverseProperty("ComplaintType")]
        public virtual ICollection<Complaint> Complaints { get; set; }
    }
}
