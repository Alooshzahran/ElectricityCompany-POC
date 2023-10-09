using Entity;
using Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryLookup : Repository<Lookup>,IRepositoryLookup
    {
        public RepositoryLookup(MyDbContext dbContext)
     : base(dbContext)
        {
        }

        public IEnumerable<Lookup> GetAllComplainingparties()
        {
            var Meth = base._myDbContext.Lookups.Where(e => e.LookupTypeId == 4);
            return Meth;
        }

        //public Lookup GetComplaintMethod(int methodId)
        //{
        //    var Meth = base._myDbContext.Lookups.FirstOrDefault(e => e.LookupTypeId == 4 && e.Id == methodId);
        //    return Meth;
        //} 
        public IEnumerable<Lookup> GetAllComplaintMethod()
        {
            var Meth = base._myDbContext.Lookups.Where(e => e.LookupTypeId == 5);
            return Meth;
        }

        public IEnumerable<Lookup> GetAllComplaintStatus()
        {
            var Deps = base._myDbContext.Lookups.Where(e => e.LookupTypeId == 8);
            return Deps;
        }

        public IEnumerable<Lookup> GetAllExportoffice()
        {
            var Deps = base._myDbContext.Lookups.Where(e => e.LookupTypeId == 3);
            return Deps;
        } 
          public IEnumerable<Lookup> GetAllArea()
        {
            var Deps = base._myDbContext.Lookups.Where(e => e.LookupTypeId == 7);
            return Deps;
        } 
        public IEnumerable<Lookup> GetAllAuditStatus()
        {
            var Deps = base._myDbContext.Lookups.Where(e => e.LookupTypeId == 6);
            return Deps;
        }

        public Lookup GetDepartments(int branchid)
        {
            var Deps =  base._myDbContext.Lookups.FirstOrDefault(e => e.LookupTypeId == 1 && e.Id == branchid);   
            return Deps;
        }

        public Lookup GetSubType(int Id)
        {
            var Deps = base._myDbContext.Lookups.FirstOrDefault(e => e.LookupTypeId == 9  && e.Id == Id);
            return Deps;
        }
    }
}
