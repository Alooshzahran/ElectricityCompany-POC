using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryLookup : IRepository<Lookup>
    {
        public Entity.Lookup GetDepartments(int branchid);
        public IEnumerable<Entity.Lookup> GetAllComplainingparties();
        public IEnumerable<Entity.Lookup> GetAllComplaintMethod();
        public IEnumerable<Entity.Lookup> GetAllComplaintStatus();
        public IEnumerable<Entity.Lookup> GetAllExportoffice();
        public IEnumerable<Entity.Lookup> GetAllArea();
        public IEnumerable<Entity.Lookup> GetAllAuditStatus();
        public Entity.Lookup GetSubType(int Id);

    }
}
