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
    public class ClientComplaintType : Client<DTO.ComplaintType>, IClientComplaintType
    {
        public ClientComplaintType(HttpClient httpClient, IOptions<ServiceSetting> serviceSetting, IHttpContextAccessor httpContext) : base(httpClient, serviceSetting, httpContext){   }

        public async Task<IEnumerable<ComplaintType>> GetComplaintTypesByCategoryId(int CategoryId)
        {
            HttpResponseMessage response = await _HttpClient.GetAsync($"ComplaintType/GetComplaintTypeByCategoryId?CategoryId={CategoryId}");
            if (response.IsSuccessStatusCode)
            {
                var ComplaintTypes = await response.Content.ReadAsStringAsync();
                IEnumerable<DTO.ComplaintType> Dept = JsonConvert.DeserializeObject<IEnumerable<DTO.ComplaintType>>(ComplaintTypes);

                return Dept;
            }
            return null;
        }
    }
}
