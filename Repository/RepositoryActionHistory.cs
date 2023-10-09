using Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryActionHistory : IRepositoryActionHistory
    {
        private readonly MyDbContext _context;
        readonly private Entity.Employee _employee;

        public RepositoryActionHistory(MyDbContext context, Entity.Employee employee)
        {
            _context = context;
            _employee = employee;
        }
        public Entity.ActionHistory InsertGeneralActionHistory(int GeneralRequestID)
        {
           
            Entity.ActionHistory ActionsHistory = new Entity.ActionHistory
            {
                RequestId = GeneralRequestID,
                StepId = (int)Classes.Steps.FirstStep,
                ActionId = Classes.Actions.Submit,
                ActionName = Classes.Actions.Submit.ToString(),
                ActionByUserName = _employee.Name,            
                ActionDateTime = DateTime.Now,
                UserActionGroup = Classes.Constants.UserGroup
            };

            _context.ActionHistories.Add(ActionsHistory);
            _context.SaveChanges();

            return ActionsHistory;
        }

        //public IEnumerable<Entity.VwGeneralActionsHistory> GetActionHistory(Int64 RequestID)
        //{
        //    return _context.VwGeneralActionsHistories.Where(e => e.RequestId == RequestID);
        //}

        public Entity.ActionHistory GetLastActionHistory(Int64 RequestID)
        {
            return _context.ActionHistories.Where(e => e.RequestId == RequestID).OrderByDescending(e => e.Id).FirstOrDefault();
        }
    }
}
