using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace Connecter.Client
{
    public interface IClientContainer
    {

        IClient<DTO.Attachment> Attachment { get; }
        IClient<DTO.Audit> Audit { get; }
        IClient<DTO.Complaint> Complaint { get; }
        IClient<DTO.ComplaintCategory> ComplaintCategory { get; }
        IClient<DTO.ComplaintType> ComplaintType{ get; }
        IClient<DTO.ComplaintResponse> ComplaintResponse { get; }
        IClient<DTO.Employee> Employee { get; }
        IClient<DTO.Lookup> Lookup { get; }
        IClient<DTO.LookupType> LookupType { get; }
        IClient<DTO.Subscriber> Subscriber { get; }
        IClient<DTO.TechnicalReport> TechnicalReport { get; }
        IClient<DTO.User> User { get; }
        ServiceSetting ServiceSetting { get; }

    }
}
