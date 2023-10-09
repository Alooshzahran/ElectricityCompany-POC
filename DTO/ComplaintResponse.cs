using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Repository;

namespace DTO
{
    public class ComplaintResponse 
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? ResponseTime { get; set; }

        public DateTime? ResponseDate { get; set; }

        public string? ReplyBookNumber { get; set; }

        public DateTime? ExportDate { get; set; }

        public int? CreationUserId { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? ModifyUserId { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? DeleteUserId { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? ComplaintStatusId { get; set; }

        public int? ExportOfficeId { get; set; }
       
        public int? EmployeeId { get; set; }
        public string? ReplyBookTopic { get; set; }
        public string? TextResponse { get; set; }

        public int? RequestId { get; set; }


        public virtual Lookup? ComplaintStatus { get; set; }
   
        public virtual User? CreationUser { get; set; }

        public virtual User? DeleteUser { get; set; }

        public virtual Employee? Employee { get; set; }

        public virtual Lookup? ExportOffice { get; set; }

        public virtual User? ModifyUser { get; set; }

        public virtual GeneralRequest? Request { get; set; }
    }
    public class ComplaintResponseValidation : AbstractValidator<ComplaintResponse>
    {
        readonly IUnitofwork _unitofwork;
        public ComplaintResponseValidation(IUnitofwork unitofwork)
        {
            _unitofwork = unitofwork;
            When(e => e.Id == 0 || (e.Id > 0 && !e.IsDeleted), () =>
            {
                RuleFor(e => e.ReplyBookTopic).NotNull().WithMessage("هذا الحقل مطلوب");
                RuleFor(e => e.ReplyBookTopic).NotEmpty().WithMessage("هذا الحقل مطلوب");
                RuleFor(e => e.TextResponse).NotNull().WithMessage("هذا الحقل مطلوب\t");
                RuleFor(e => e.TextResponse).NotEmpty().WithMessage("هذا الحقل مطلوب\t");
                //RuleFor(e => e.AuditStatusId).NotNull().WithMessage("هذا الحقل مطلوب\t");
                //RuleFor(e => e.AuditStatusId).NotEmpty().WithMessage("هذا الحقل مطلوب\t");
                RuleFor(e => e.EmployeeId).NotNull().WithMessage("هذا الحقل مطلوب\t");
                RuleFor(e => e.EmployeeId).NotEmpty().WithMessage("هذا الحقل مطلوب\t");
                //When(e => e.AuditStatusId != null && e.AuditStatusId != 0, () =>
                //{
                //    RuleFor(x => x.AuditStatusId).Must(IsAuditStatusIdExist).WithMessage("قيمة الحقل غير موجودة\t");
                //});
                When(e => e.EmployeeId != null && e.EmployeeId != 0, () =>
                {
                    RuleFor(x => x.EmployeeId).Must(IsEmployeeIdExist).WithMessage("قيمة الحقل غير موجودة\t");
                });
            });


        }
        private bool IsEmployeeIdExist(int? EmployeeID)
        {
            return _unitofwork.employee.GetByID(EmployeeID ?? 0) != null;
        }
        private bool IsAuditStatusIdExist(int? AuditStatusId)
        {
            return _unitofwork.LookupType.GetByID(AuditStatusId ?? 0) != null;
        }
    }
}
