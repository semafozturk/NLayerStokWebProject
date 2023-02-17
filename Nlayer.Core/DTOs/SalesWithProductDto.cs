using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core.DTOs
{
    public class SalesWithProductDto:SaleDto
    {
        public ProductDto Product { get; set; }
    }
}
