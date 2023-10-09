using Entity;
using Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryComplaintType : Repository<ComplaintType>, IRepositoryComplaintType
    {
        public RepositoryComplaintType(MyDbContext dbContext)
     : base(dbContext)
        {
        }

        public IEnumerable<ComplaintType> GetComplaintTypeByCategoryId(int categoryId)
        {
            IEnumerable<ComplaintType> complaintTypes = base._myDbContext.ComplaintTypes.Where(e => e.ComplaintCategoryId == categoryId);
            return complaintTypes;
        }
    }
}
