using Connecter.Client;
using Entity.Repository;

namespace UI.Repositries
{
    public class RepositoryActionHistory : IRepositoryActionHistory
    {
        private MyDbContext _context { get; set; }
        private readonly IClientContainer _clientContainer;

        public RepositoryActionHistory(MyDbContext context, IClientContainer clientContainer)
        {
            _context = context;
            _clientContainer = clientContainer;
        }
        public async Task<Entity.ActionHistory> InsertGeneralActionHistory(int GeneralRequestID)
        {
            var emp = await _clientContainer.Employee.GetByID(1);
            Entity.ActionHistory ActionsHistory = new Entity.ActionHistory
            {
                RequestId = GeneralRequestID,
                StepId = (int)Classes.Steps.Requester,
                ActionId = (int)Classes.Actions.Submit,
                ActionName = Classes.Actions.Submit.ToString(),
                ActionByUserName = emp.Name,
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
