using Nlayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core.Services
{
    public interface ISaleService:IService<Sale>
    {
        Task<List<SalesWithProductDto>> GetSalesWithProduct();
    }
}
