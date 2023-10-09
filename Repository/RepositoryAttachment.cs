using Entity;
using Entity.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryAttachment : Repository<Attachment>,IRepositoryAttachment
    {
        public RepositoryAttachment(MyDbContext dbContext)
       : base(dbContext)
        {
        }
    }
}
