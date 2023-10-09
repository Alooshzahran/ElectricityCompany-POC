using Connecter.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public class ClientLookup : Client<DTO.Lookup>, IClientLookup
    {
        public ClientLookup(HttpClient httpClient, IOptions<ServiceSetting> serviceSetting, IHttpContextAccessor httpContext) : base(httpClient, serviceSetting, httpContext)
        {
            
        }

        public async Task<IEnumerable<Lookup>> GetAllparties()
        {
            HttpResponseMessage response = await _HttpClient.GetAsync("Lookup/GetAllparties");
            if (response.IsSuccessStatusCode)
            {
                var Department = await response.Content.ReadAsStringAsync();
               IEnumerable<DTO.Lookup> Dept = JsonConvert.DeserializeObject<IEnumerable<DTO.Lookup>>(Department);

                return Dept;
            }
            return null;
        } 
        public async Task<IEnumerable<Lookup>> GetAllMethod()
        {
            HttpResponseMessage response = await _HttpClient.GetAsync("Lookup/GetAllMethod");
            if (response.IsSuccessStatusCode)
            {
                var Department = await response.Content.ReadAsStringAsync();
               IEnumerable<DTO.Lookup> Dept = JsonConvert.DeserializeObject<IEnumerable<DTO.Lookup>>(Department);

                return Dept;
            }
            return null;
        }
        public async Task<IEnumerable<Lookup>> GetAllComplaintStatus()
        {
            HttpResponseMessage response = await _HttpClient.GetAsync("Lookup/GetAllComplaintStatus");
            if (response.IsSuccessStatusCode)
            {
                var Department = await response.Content.ReadAsStringAsync();
                IEnumerable<DTO.Lookup> Dept = JsonConvert.DeserializeObject<IEnumerable<DTO.Lookup>>(Department);

                return Dept;
            }
            return null;
        }
        public async Task<IEnumerable<Lookup>> GetAllArea()
        {
            HttpResponseMessage response = await _HttpClient.GetAsync("Lookup/GetAllArea");
            if (response.IsSuccessStatusCode)
            {
                var Department = await response.Content.ReadAsStringAsync();
                IEnumerable<DTO.Lookup> Dept = JsonConvert.DeserializeObject<IEnumerable<DTO.Lookup>>(Department);

                return Dept;
            }
            return null;
        }
        public async Task<string> GetDept(int DeptId)
        {
            HttpResponseMessage response = await _HttpClient.GetAsync("Lookup/GetDept?Id=" +DeptId );
            if (response.IsSuccessStatusCode)
            {
                var Department = await response.Content.ReadAsStringAsync();
               //DTO.Lookup Dept = JsonConvert.DeserializeObject<DTO.Lookup>(Department);

                return Department;
            }
            return null;
        }
        public async Task<string> GetSubType(int Id)
        {
            HttpResponseMessage response = await _HttpClient.GetAsync("Lookup/GetAllSubType?Id=" + Id);
            if (response.IsSuccessStatusCode)
            {
                var Department = await response.Content.ReadAsStringAsync();
             

                return Department;
            }
            return null;
        }

        public async Task<IEnumerable<Lookup>> GetAllExportoffice()
        {
            HttpResponseMessage response = await _HttpClient.GetAsync("Lookup/GetAllExportoffice");
            if (response.IsSuccessStatusCode)
            {
                var Department = await response.Content.ReadAsStringAsync();
                IEnumerable<DTO.Lookup> Dept = JsonConvert.DeserializeObject<IEnumerable<DTO.Lookup>>(Department);

                return Dept;
            }
            return null;
        }
        public async Task<IEnumerable<Lookup>> GetAllAuditStatus()
        {
            HttpResponseMessage response = await _HttpClient.GetAsync("Lookup/GetAllAuditStatus");
            if (response.IsSuccessStatusCode)
            {
                var Department = await response.Content.ReadAsStringAsync();
                IEnumerable<DTO.Lookup> Dept = JsonConvert.DeserializeObject<IEnumerable<DTO.Lookup>>(Department);

                return Dept;
            }
            return null;
        }
    }
}
