﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public interface IClientComplaintType : IClient<ComplaintType>
    {
        public Task<IEnumerable<ComplaintType>> GetComplaintTypesByCategoryId(int CategoryId);
    }
}
