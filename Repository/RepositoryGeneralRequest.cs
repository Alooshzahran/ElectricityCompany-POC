using Entity.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryGeneralRequest : IRepositoryGeneralRequest
    {
        readonly private MyDbContext _context;
        readonly private Entity.Employee _employee;
        public RepositoryGeneralRequest(MyDbContext context, Entity.Employee employee)
        {
            _context = context;
            _employee = employee;
        }
        public Int64 NewProcessID()
        {
            var SelectedGeneralRequest = _context.GeneralRequests.OrderByDescending(e => e.ProcessId).FirstOrDefault();
            if (SelectedGeneralRequest == null)
                return 1;
            else
                return SelectedGeneralRequest.ProcessId.Value + 1;
        }
        public Entity.GeneralRequest InsertGeneralRequest(int TableID, int ServiceTypeID, int StepID)
        {

            Entity.GeneralRequest generalRequest = new Entity.GeneralRequest
            {
                RequestNo = TableID,
                EmpUserName = _employee.Name,
                EmpFullNameAr = _employee.NameArabic,
                EmpFullNameEn = _employee.Name,
                EmpNumber = (_employee.Id).ToString(),
                ActionLastDateTime = DateTime.Now,
                CreatedBy = _employee.NameArabic,
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

        //public IEnumerable<Entity.VwGeneralRequest> GetMyRequests(string EmployeeUserName)
        //{
        //    return _context.VwGeneralRequests.Where(e => e.EmpUserName.ToLower() == EmployeeUserName.ToLower()).OrderByDescending(e => e.CreatedDateTime);
        //}

        //public Entity.VwGeneralRequest Get(int ProcessId)
        //{
        //    return _DBContext.VwGeneralRequests.FirstOrDefault(e => e.ProcessId == ProcessId);
        //}
    }
}
