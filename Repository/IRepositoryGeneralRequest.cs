using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryGeneralRequest
    {
        public Int64 NewProcessID();
        public Entity.GeneralRequest InsertGeneralRequest(int TableID, int ServiceTypeID, int StepID);
    }
}
