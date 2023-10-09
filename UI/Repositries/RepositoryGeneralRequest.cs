using Connecter.Client;
using Entity.Repository;
using Microsoft.EntityFrameworkCore;

namespace UI.Repositries
{
    public class RepositoryGeneralRequest : IRepositoryGeneralRequest
    {
        private MyDbContext _context { get; set; }
        private readonly IClientContainer _clientContainer;
        public RepositoryGeneralRequest(MyDbContext context, IClientContainer clientContainer)
        {
            _context = context;
           _clientContainer = clientContainer;
        }
        public Int64 NewProcessID()
        {
            var SelectedGeneralRequest = _context.GeneralRequests.OrderByDescending(e => e.ProcessId).FirstOrDefault();
            if (SelectedGeneralRequest == null)
                return 1;
            else
                return SelectedGeneralRequest.ProcessId.Value + 1;
        }
        public async Task<Entity.GeneralRequest> InsertGeneralRequest(int TableID, int ServiceTypeID, int StepID)
        {
            var emp = await _clientContainer.Employee.GetByID(1);
            Entity.GeneralRequest generalRequest = new Entity.GeneralRequest
            {
                RequestNo = TableID,
                EmpUserName = emp.Name,
                EmpFullNameAr = emp.NameArabic,
                EmpFullNameEn = emp.Name,
                EmpNumber = (emp.Id).ToString(),
                ActionLastDateTime = DateTime.Now,
                CreatedBy = emp.NameArabic,
                CreatedDateTime = DateTime.Now,
                OnBehalf = false,
                ServiceTypeId = ServiceTypeID,
                StatusId = "1",
                StepId = StepID,
                ProcessId = null// _GeneralRequest.NewProcessID(),
            };


            _context.GeneralRequests.Add(generalRequest);
            _context.SaveChanges();

            return generalRequest;
        }
        public Entity.GeneralRequest Get(int ProcessId)
        {
            return _context.GeneralRequests.FirstOrDefault(e => e.ProcessId == ProcessId);
        }
        public IEnumerable<Entity.GeneralRequest> GetAll()
        {
            return _context.Set<Entity.GeneralRequest>().ToList();
        }
        public Entity.GeneralRequest GetByID(int id)
        {
            return _context.Set<Entity.GeneralRequest>().FirstOrDefault(e => e.RequestId == id);
        }
        public Entity.GeneralRequest Update(Entity.GeneralRequest GeneralRequest)
        {
            return _context.Set<Entity.GeneralRequest>().Update(GeneralRequest).Entity;
        }
    }
}
