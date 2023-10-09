using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryActionHistory
    {
        public Entity.ActionHistory InsertGeneralActionHistory(int GeneralRequestID);
        //public IEnumerable<Entity.VwGeneralActionsHistory> GetActionHistory(Int64 RequestID);
        public Entity.ActionHistory GetLastActionHistory(Int64 RequestID);

    }
}
