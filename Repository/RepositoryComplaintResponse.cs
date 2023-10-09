using Entity;
using Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryComplaintResponse : Repository<ComplaintResponse>, IRepositoryComplaintResponse
    {
        public RepositoryComplaintResponse(MyDbContext dbContext)
     : base(dbContext)
        {
        }
    }
}
