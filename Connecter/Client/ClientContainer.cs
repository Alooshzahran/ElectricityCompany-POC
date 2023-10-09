using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public class ClientContainer : IClientContainer
    {
        public ServiceSetting ServiceSetting { get; private set; }

        public IClient<Attachment> Attachment { get; private set; }

        public IClient<Audit> Audit { get; private set; }

        public IClient<Complaint> Complaint { get; private set; }

        public IClient<ComplaintCategory> ComplaintCategory { get; private set; }

        public IClient<ComplaintResponse> ComplaintResponse { get; private set; }

        public IClient<Employee> Employee { get; private set; }

        public IClient<Lookup> Lookup { get; private set; }

        public IClient<LookupType> LookupType { get; private set; }

        public IClient<Subscriber> Subscriber { get; private set; }

        public IClient<TechnicalReport> TechnicalReport { get; private set; }

        public IClient<User> User { get; private set; }

        public IClient<ComplaintType> ComplaintType { get; private set; }

        public ClientContainer(HttpClient httpClient, IOptions<ServiceSetting> serviceSetting, IHttpContextAccessor httpContext)
        {
            ServiceSetting = serviceSetting.Value;
            Attachment = new Client<Attachment>(httpClient, serviceSetting, httpContext);
            Audit = new Client<Audit>(httpClient, serviceSetting, httpContext);
            Complaint = new Client<Complaint>(httpClient, serviceSetting, httpContext);
            ComplaintCategory = new Client<ComplaintCategory>(httpClient, serviceSetting, httpContext);
            ComplaintResponse = new Client<ComplaintResponse>(httpClient, serviceSetting, httpContext);
            Employee = new Client<Employee>(httpClient, serviceSetting, httpContext);
            Lookup = new Client<Lookup>(httpClient, serviceSetting, httpContext);
            LookupType = new Client<LookupType>(httpClient, serviceSetting, httpContext);
            Subscriber = new Client<Subscriber>(httpClient, serviceSetting, httpContext);
            TechnicalReport = new Client<TechnicalReport>(httpClient, serviceSetting, httpContext);
            User = new Client<User>(httpClient, serviceSetting, httpContext);
            ComplaintType = new Client<ComplaintType>(httpClient, serviceSetting, httpContext);

        }
    }
}
