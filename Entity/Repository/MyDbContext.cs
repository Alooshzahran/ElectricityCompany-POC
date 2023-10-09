using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entity;

namespace Entity.Repository
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Action> Actions { get; set; } = null!;
        public virtual DbSet<ActionHistory> ActionHistories { get; set; } = null!;
        public virtual DbSet<Attachment> Attachments { get; set; } = null!;
        public virtual DbSet<Audit> Audits { get; set; } = null!;
        public virtual DbSet<Complaint> Complaints { get; set; } = null!;
        public virtual DbSet<ComplaintCategory> ComplaintCategories { get; set; } = null!;
        public virtual DbSet<ComplaintResponse> ComplaintResponses { get; set; } = null!;
        public virtual DbSet<ComplaintType> ComplaintTypes { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<GeneralRequest> GeneralRequests { get; set; } = null!;
        public virtual DbSet<GeneralService> GeneralServices { get; set; } = null!;
        public virtual DbSet<GeneralServiceType> GeneralServiceTypes { get; set; } = null!;
        public virtual DbSet<GeneralStep> GeneralSteps { get; set; } = null!;
        public virtual DbSet<GenralStatus> GenralStatuses { get; set; } = null!;
        public virtual DbSet<Lookup> Lookups { get; set; } = null!;
        public virtual DbSet<LookupType> LookupTypes { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Subscriber> Subscribers { get; set; } = null!;
        public virtual DbSet<TechnicalReport> TechnicalReports { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=154.12.237.206;Initial Catalog=IrbidElectricity;User ID=zuhairi;Password=!@mr!D!@b");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionHistory>(entity =>
            {
                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ActionHistories)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("fk_actionhistory_action");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ActionHistories)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("fk_actionhistory_RequestID");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.ActionHistories)
                    .HasForeignKey(d => d.StepId)
                    .HasConstraintName("fk_actionhistory_general_steps");
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CreationUser)
                    .WithMany(p => p.AttachmentCreationUsers)
                    .HasForeignKey(d => d.CreationUserId)
                    .HasConstraintName("fk_attachment_users_CreationUser");

                entity.HasOne(d => d.DeleteUser)
                    .WithMany(p => p.AttachmentDeleteUsers)
                    .HasForeignKey(d => d.DeleteUserId)
                    .HasConstraintName("fk_attachment_users_DeleteUser");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.AttachmentModifyUsers)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_attachment_users_ModifyUser");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("fk_attachment_general_requests_RequestID");
            });

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

         

                entity.HasOne(d => d.CreationUser)
                    .WithMany(p => p.AuditCreationUsers)
                    .HasForeignKey(d => d.CreationUserId)
                    .HasConstraintName("fk_audit_users_CreationUser");

                entity.HasOne(d => d.DeleteUser)
                    .WithMany(p => p.AuditDeleteUsers)
                    .HasForeignKey(d => d.DeleteUserId)
                    .HasConstraintName("fk_audit_users_DeleteUser");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Audits)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_Audit_Employee");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.AuditModifyUsers)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_audit_users_ModifyUser");
            });

            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.ComplaintAreas)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("fk_complaint_lockup_Area");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ComplaintCities)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("fk_complaint_lookup_City");

                entity.HasOne(d => d.Complainingparties)
                    .WithMany(p => p.ComplaintComplainingparties)
                    .HasForeignKey(d => d.ComplainingpartiesId)
                    .HasConstraintName("fk_complaint_lookup_Complainingparties");

                entity.HasOne(d => d.ComplaintMethod)
                    .WithMany(p => p.ComplaintComplaintMethods)
                    .HasForeignKey(d => d.ComplaintMethodId)
                    .HasConstraintName("fk_complaint_lookup_ComplaintMethod");

                entity.HasOne(d => d.ComplaintSource)
                    .WithMany(p => p.ComplaintComplaintSources)
                    .HasForeignKey(d => d.ComplaintSourceId)
                    .HasConstraintName("fk_complaint_lockup");

                entity.HasOne(d => d.ComplaintStatus)
                    .WithMany(p => p.ComplaintComplaintStatuses)
                    .HasForeignKey(d => d.ComplaintStatusId)
                    .HasConstraintName("fk_complaint_lookup_ComplaintStatus");

                entity.HasOne(d => d.ComplaintType)
                    .WithMany(p => p.Complaints)
                    .HasForeignKey(d => d.ComplaintTypeId)
                    .HasConstraintName("fk_complaint_complainttype");

                entity.HasOne(d => d.CreationUser)
                    .WithMany(p => p.ComplaintCreationUsers)
                    .HasForeignKey(d => d.CreationUserId)
                    .HasConstraintName("fk_complaint_users_CreationUser");

                entity.HasOne(d => d.DeleteUser)
                    .WithMany(p => p.ComplaintDeleteUsers)
                    .HasForeignKey(d => d.DeleteUserId)
                    .HasConstraintName("fk_complaint_users_DeleteUser");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.ComplaintModifyUsers)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_complaint_users_ModifyUser");

                entity.HasOne(d => d.OfficialComplainingParties)
                    .WithMany(p => p.ComplaintOfficialComplainingParties)
                    .HasForeignKey(d => d.OfficialComplainingPartiesId)
                    .HasConstraintName("fk_complaint_lookup_OfficialComplainingParties");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Complaints)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("fk_complaint_general_requests_RequestID");

                entity.HasOne(d => d.Subscriber)
                    .WithMany(p => p.Complaints)
                    .HasForeignKey(d => d.SubscriberId)
                    .HasConstraintName("fk_complaint_subscriber");
            });

            modelBuilder.Entity<ComplaintCategory>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CreationUser)
                    .WithMany(p => p.ComplaintCategoryCreationUsers)
                    .HasForeignKey(d => d.CreationUserId)
                    .HasConstraintName("fk_complaintcategory_users_CreationUser");

                entity.HasOne(d => d.DeleteUser)
                    .WithMany(p => p.ComplaintCategoryDeleteUsers)
                    .HasForeignKey(d => d.DeleteUserId)
                    .HasConstraintName("fk_complaintcategory_users_DeleteUser");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.ComplaintCategoryModifyUsers)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_complaintcategory_users_ModifyUser");
            });

            modelBuilder.Entity<ComplaintResponse>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ComplaintStatus)
                    .WithMany(p => p.ComplaintResponseComplaintStatuses)
                    .HasForeignKey(d => d.ComplaintStatusId)
                    .HasConstraintName("fk_complaintresponse_lookup_ComplaintStatus");

                entity.HasOne(d => d.CreationUser)
                    .WithMany(p => p.ComplaintResponseCreationUsers)
                    .HasForeignKey(d => d.CreationUserId)
                    .HasConstraintName("fk_complaintresponse_users_CreationUser");

                entity.HasOne(d => d.DeleteUser)
                    .WithMany(p => p.ComplaintResponseDeleteUsers)
                    .HasForeignKey(d => d.DeleteUserId)
                    .HasConstraintName("fk_complaintresponse_users_DeleteUser");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ComplaintResponses)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_complaintresponse_employee");

                entity.HasOne(d => d.ExportOffice)
                    .WithMany(p => p.ComplaintResponseExportOffices)
                    .HasForeignKey(d => d.ExportOfficeId)
                    .HasConstraintName("fk_complaintresponse_lookup_ExportOffice");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.ComplaintResponseModifyUsers)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_complaintresponse_users_ModifyUser");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ComplaintResponses)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("fk_complaintresponse");
            });

            modelBuilder.Entity<ComplaintType>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ComplaintCategory)
                    .WithMany(p => p.ComplaintTypes)
                    .HasForeignKey(d => d.ComplaintCategoryId)
                    .HasConstraintName("fk_complainttype_Category");

                entity.HasOne(d => d.CreationUser)
                    .WithMany(p => p.ComplaintTypeCreationUsers)
                    .HasForeignKey(d => d.CreationUserId)
                    .HasConstraintName("fk_complainttype_users_CreationUser");

                entity.HasOne(d => d.DeleteUser)
                    .WithMany(p => p.ComplaintTypeDeleteUsers)
                    .HasForeignKey(d => d.DeleteUserId)
                    .HasConstraintName("fk_complainttype_users_DeleteUser");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.ComplaintTypeModifyUsers)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_complainttype_users_ModifyUser");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.EmployeeBranches)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("fk_employee_lookup_Branch");

                entity.HasOne(d => d.ComplainingParties)
                    .WithMany(p => p.EmployeeComplainingParties)
                    .HasForeignKey(d => d.ComplainingPartiesId)
                    .HasConstraintName("fk_employee_lookup_ComplainingParties");

                entity.HasOne(d => d.CreationUser)
                    .WithMany(p => p.EmployeeCreationUsers)
                    .HasForeignKey(d => d.CreationUserId)
                    .HasConstraintName("fk_employee_users_CreationUser");

                entity.HasOne(d => d.DeleteUser)
                    .WithMany(p => p.EmployeeDeleteUsers)
                    .HasForeignKey(d => d.DeleteUserId)
                    .HasConstraintName("fk_employee_users_DeleteUser");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeDepartments)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("fk_Employee_Department");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.EmployeeModifyUsers)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_employee_users_ModifyUser");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("fk_employee_general_requests");
            });

            modelBuilder.Entity<GeneralRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("pk_General_Request");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.GeneralRequests)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .HasConstraintName("fk_general_requests");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.GeneralRequests)
                    .HasForeignKey(d => d.StepId)
                    .HasConstraintName("fk_general_requests_Step");
            });

            modelBuilder.Entity<GeneralService>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("pk_general_Services");
            });

            modelBuilder.Entity<GeneralServiceType>(entity =>
            {
                entity.HasKey(e => e.Stid)
                    .HasName("pk_general_serviceType");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.GeneralServiceTypes)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("fk_general_servicetype_Service");
            });

            modelBuilder.Entity<GeneralStep>(entity =>
            {
                entity.HasKey(e => e.Stid)
                    .HasName("pk_general_steps");
            });

            modelBuilder.Entity<Lookup>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.LookupType)
                    .WithMany(p => p.LookupLookupTypes)
                    .HasForeignKey(d => d.LookupTypeId)
                    .HasConstraintName("fk_lookup_lookuptype");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.LookupParents)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_Parent");
            });

            modelBuilder.Entity<LookupType>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("pk_Service");
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CreationUser)
                    .WithMany(p => p.SubscriberCreationUsers)
                    .HasForeignKey(d => d.CreationUserId)
                    .HasConstraintName("fk_subscriber_users_CreationUser");

                entity.HasOne(d => d.DeleteUser)
                    .WithMany(p => p.SubscriberDeleteUsers)
                    .HasForeignKey(d => d.DeleteUserId)
                    .HasConstraintName("fk_subscriber_users_DeleteUser");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.SubscriberModifyUsers)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_subscriber_users_ModifyUser");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Subscribers)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("fk_subscriber_general_requests_RequestID");

                entity.HasOne(d => d.SubscriptionType)
                    .WithMany(p => p.Subscribers)
                    .HasForeignKey(d => d.SubscriptionTypeId)
                    .HasConstraintName("fk_subscriber_lockup_SbscriptionType");
            });

            modelBuilder.Entity<TechnicalReport>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CreationUser)
                    .WithMany(p => p.TechnicalReportCreationUsers)
                    .HasForeignKey(d => d.CreationUserId)
                    .HasConstraintName("fk_technicalreport_users_CreationUser");

                entity.HasOne(d => d.DeleteUser)
                    .WithMany(p => p.TechnicalReportDeleteUsers)
                    .HasForeignKey(d => d.DeleteUserId)
                    .HasConstraintName("fk_technicalreport_users_DeleteUser");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.TechnicalReportModifyUsers)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_technicalreport_users_ModifyUser");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.TechnicalReports)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("fk_technicalreport_RequestID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
