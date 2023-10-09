using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryComplaintType : IRepository<ComplaintType>
    {
        public IEnumerable<Entity.ComplaintType> GetComplaintTypeByCategoryId(int categoryId);
    }
}
