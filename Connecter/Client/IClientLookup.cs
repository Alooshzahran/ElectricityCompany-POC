using Connecter.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public interface IClientLookup : IClient<Lookup>
    {
        public Task<string> GetDept(int id);
        public Task<string> GetSubType(int id);
        public Task<IEnumerable<Lookup>> GetAllMethod();
        public Task<IEnumerable<Lookup>> GetAllArea();
        public Task<IEnumerable<Lookup>> GetAllComplaintStatus();
        public Task<IEnumerable<Lookup>> GetAllExportoffice();
        public Task<IEnumerable<Lookup>> GetAllAuditStatus();
        
        public Task<IEnumerable<Lookup>> GetAllparties();
    }
}
