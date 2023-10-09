using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Audit 
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int? EmployeeId { get; set; }

        public DateTime? AuditDate { get; set; }

        public int? AuditStatusId { get; set; }
        public string? AuditRemark { get; set; }

        public int? CreationUserId { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? ModifyUserId { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? DeleteUserId { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? RequestId { get; set; }


        public virtual User? CreationUser { get; set; }

        public virtual User? DeleteUser { get; set; }

        public virtual Employee? Employee { get; set; }

        public virtual User? ModifyUser { get; set; }
    }
    public class AuditValidation : AbstractValidator<Audit>
    {
        readonly IUnitofwork _unitofwork;
        public AuditValidation(IUnitofwork unitofwork) 
        {
            _unitofwork = unitofwork;
            When(e => e.Id == 0 || (e.Id > 0 && !e.IsDeleted), () =>
            {
                RuleFor(e => e.AuditDate).NotNull().WithMessage("هذا الحقل مطلوب");
                RuleFor(e => e.AuditDate).NotEmpty().WithMessage("هذا الحقل مطلوب");
                RuleFor(e => e.AuditRemark).NotNull().WithMessage("هذا الحقل مطلوب\t");
                RuleFor(e => e.AuditRemark).NotEmpty().WithMessage("هذا الحقل مطلوب\t");
                RuleFor(e => e.AuditStatusId).NotNull().WithMessage("هذا الحقل مطلوب\t");
                RuleFor(e => e.AuditStatusId).NotEmpty().WithMessage("هذا الحقل مطلوب\t");
                RuleFor(e => e.EmployeeId).NotNull().WithMessage("هذا الحقل مطلوب\t");
                RuleFor(e => e.EmployeeId).NotEmpty().WithMessage("هذا الحقل مطلوب\t");

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

    }

}
