using Entity.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Unitofwork : IUnitofwork
    {
        private readonly MyDbContext _context;

        public IRepositoryAttachment attachment {get; private set;}
        public IRepositoryAudit audit {get; private set;}

        public IRepositoryComplaint complaint { get; private set; }

        public IRepositoryComplaintCategory complaintCategory { get; private set; }

        public IRepositoryComplaintResponse complaintResponse { get; private set; }

        public IRepositoryComplaintType complaintType { get; private set; }

        public IRepositoryEmployee employee { get; private set; }

        public IRepositoryLookup Lookup { get; private set; }

        public IRepositoryLookupType LookupType { get; private set; }

        public IRepositorySubscriber subscriber { get; private set; } 

        public IRepositoryUser user { get; private set; }

        public IRepositoryTechnicalReport technicalReport { get; private set; }

        public Unitofwork(MyDbContext context)
        {
            _context = context;
            attachment = new RepositoryAttachment(context);
            audit = new RepositoryAudit(context);
            complaint = new RepositoryComplaint(context);
            complaintCategory = new RepositoryComplaintCategory(context);
            complaintResponse = new RepositoryComplaintResponse(context);
            complaintType = new RepositoryComplaintType(context);
            employee = new RepositoryEmployee(context);
            Lookup = new RepositoryLookup(context);
            LookupType = new RepositoryLookupType(context);
            subscriber = new RepositorySubscriber(context);
            technicalReport = new RepositoryTechnicalReport(context);
            user = new RepositoryUser(context);
        }
        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
