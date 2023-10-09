using AutoMapper;

namespace API.Helper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entity.Attachment,DTO.Attachment>();
            CreateMap<DTO.Attachment, Entity.Attachment>()
               .AfterMap((source, destination) =>
               {
                   if (destination.Id == 0)
                   {
                       destination.ModifyUserId = null;
                       destination.ModifyDate = null;
                       destination.DeleteUserId = null;
                       destination.DeleteDate = null;
                       destination.IsDeleted = false;
                   }
               });
            CreateMap<Entity.Audit,DTO.Audit>();
            CreateMap<DTO.Audit, Entity.Audit>()
               .AfterMap((source, destination) =>
               {
                   if (destination.Id == 0)
                   {
                       destination.ModifyUserId = null;
                       destination.ModifyDate = null;
                       destination.DeleteUserId = null;
                       destination.DeleteDate = null;
                       destination.IsDeleted = false;
                   }
               });
            CreateMap<Entity.Complaint,DTO.Complaint>();
            CreateMap<DTO.Complaint, Entity.Complaint>()
               .AfterMap((source, destination) =>
               {
                   if (destination.Id == 0)
                   {
                       destination.ModifyUserId = null;
                       destination.ModifyDate = null;
                       destination.DeleteUserId = null;
                       destination.DeleteDate = null;
                       destination.IsDeleted = false;
                   }
               });
            CreateMap<Entity.ComplaintCategory,DTO.ComplaintCategory>();
            CreateMap<DTO.ComplaintCategory, Entity.ComplaintCategory>()
               .AfterMap((source, destination) =>
               {
                   if (destination.Id == 0)
                   {
                       destination.ModifyUserId = null;
                       destination.ModifyDate = null;
                       destination.DeleteUserId = null;
                       destination.DeleteDate = null;
                       destination.IsDeleted = false;
                   }
               });
            CreateMap<Entity.ComplaintResponse, DTO.ComplaintResponse>();
            CreateMap<DTO.ComplaintResponse, Entity.ComplaintResponse>()
               .AfterMap((source, destination) =>
               {
                   if (destination.Id == 0)
                   {
                       destination.ModifyUserId = null;
                       destination.ModifyDate = null;
                       destination.DeleteUserId = null;
                       destination.DeleteDate = null;
                       destination.IsDeleted = false;
                   }
               });
            CreateMap<Entity.ComplaintType,DTO.ComplaintType>();
            CreateMap<DTO.ComplaintType, Entity.ComplaintType>()
               .AfterMap((source, destination) =>
               {
                   if (destination.Id == 0)
                   {
                       destination.ModifyUserId = null;
                       destination.ModifyDate = null;
                       destination.DeleteUserId = null;
                       destination.DeleteDate = null;
                       destination.IsDeleted = false;
                   }
               });
            CreateMap<Entity.Employee,DTO.Employee>();
            CreateMap<DTO.Employee, Entity.Employee>()
               .AfterMap((source, destination) =>
               {
                   if (destination.Id == 0)
                   {
                       destination.ModifyUserId = null;
                       destination.ModifyDate = null;
                       destination.DeleteUserId = null;
                       destination.DeleteDate = null;
                       destination.IsDeleted = false;
                   }
               });
            CreateMap<Entity.Lookup,DTO.Lookup>();
            CreateMap<DTO.Lookup, Entity.Lookup>()
               .AfterMap((source, destination) =>
               {
                   if (destination.Id == 0)
                   {
                       destination.ModifyUserId = null;
                       destination.ModifyDate = null;
                       destination.DeleteUserId = null;
                       destination.DeleteDate = null;
                       destination.IsDeleted = false;
                   }
               });
             CreateMap<Entity.LookupType,DTO.LookupType>();
            CreateMap<DTO.LookupType, Entity.LookupType>()
               .AfterMap((source, destination) =>
               {
                   if (destination.Id == 0)
                   {
                       destination.ModifyUserId = null;
                       destination.ModifyDate = null;
                       destination.DeleteUserId = null;
                       destination.DeleteDate = null;
                       destination.IsDeleted = false;
                   }
               });
             CreateMap<Entity.Subscriber,DTO.Subscriber>();
            CreateMap<DTO.Subscriber, Entity.Subscriber>()
               .AfterMap((source, destination) =>
               {
                   if (destination.Id == 0)
                   {
                       destination.ModifyUserId = null;
                       destination.ModifyDate = null;
                       destination.DeleteUserId = null;
                       destination.DeleteDate = null;
                       destination.IsDeleted = false;
                   }
               });
             CreateMap<Entity.TechnicalReport,DTO.TechnicalReport>();
            CreateMap<DTO.TechnicalReport, Entity.TechnicalReport>()
               .AfterMap((source, destination) =>
               {
                   if (destination.Id == 0)
                   {
                       destination.ModifyUserId = null;
                       destination.ModifyDate = null;
                       destination.DeleteUserId = null;
                       destination.DeleteDate = null;
                       destination.IsDeleted = false;
                   }
               });
             CreateMap<Entity.User,DTO.User>();
            CreateMap<DTO.User, Entity.User>()
               .AfterMap((source, destination) =>
               {
                   if (destination.Id == 0)
                   {
                       destination.ModifyUserId = null;
                       destination.ModifyDate = null;
                       destination.DeleteUserId = null;
                       destination.DeleteDate = null;
                       destination.IsDeleted = false;
                   }
               });

        }
    }
}
