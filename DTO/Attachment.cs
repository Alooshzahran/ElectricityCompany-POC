using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Attachment 
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
        public string? Description { get; set; }

        public string? Attachment1 { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? AttachmentGroup { get; set; }

        public int? RequestId { get; set; }

        public int? CreationUserId { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? ModifyUserId { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? DeleteUserId { get; set; }

        public DateTime? DeleteDate { get; set; }


        public virtual User? CreationUser { get; set; }

        public virtual User? DeleteUser { get; set; }

        public virtual User? ModifyUser { get; set; }

        public virtual GeneralRequest? Request { get; set; }
    }
}
