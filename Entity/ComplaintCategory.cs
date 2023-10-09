using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    [Table("ComplaintCategory")]
    public partial class ComplaintCategory : BaseGet
    {
        public ComplaintCategory()
        {
            ComplaintTypes = new HashSet<ComplaintType>();
        }


        [StringLength(50)]
        public string? Name { get; set; }
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

        [ForeignKey("CreationUserId")]
        [InverseProperty("ComplaintCategoryCreationUsers")]
        public virtual User? CreationUser { get; set; }
        [ForeignKey("DeleteUserId")]
        [InverseProperty("ComplaintCategoryDeleteUsers")]
        public virtual User? DeleteUser { get; set; }
        [ForeignKey("ModifyUserId")]
        [InverseProperty("ComplaintCategoryModifyUsers")]
        public virtual User? ModifyUser { get; set; }
        [InverseProperty("ComplaintCategory")]
        public virtual ICollection<ComplaintType> ComplaintTypes { get; set; }
    }
}
