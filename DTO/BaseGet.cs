using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BaseGet
    {
        public int Id { get; set; }
        public int? CreationUserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? ModifyUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeleteUserID { get; set; }
        public DateTime? DeleteDate { get; set; }
 
    }
}
