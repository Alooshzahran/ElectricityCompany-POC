using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitofwork  : IDisposable
    {
        IRepositoryAttachment attachment { get; } 
        IRepositoryAudit audit { get; }
        IRepositoryComplaint complaint { get; }
        IRepositoryComplaintCategory complaintCategory { get; }
        IRepositoryComplaintResponse complaintResponse { get; }
        IRepositoryComplaintType complaintType { get; }
        IRepositoryEmployee employee { get; }
        IRepositoryLookup Lookup { get; }
        IRepositoryLookupType LookupType { get; }
        IRepositorySubscriber subscriber { get; }
        IRepositoryTechnicalReport technicalReport { get; }
        IRepositoryUser user { get; }
        void Complete();
    }
}
