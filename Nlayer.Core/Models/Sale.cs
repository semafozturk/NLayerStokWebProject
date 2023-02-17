using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core
{
    public class Sale
    {
        public int saleId { get; set; }
        public int salesQuantity { get; set; }
        public DateTime saleDate { get; set; }
        public string comment { get; set; }
        public int productId { get; set; }
        public Product Product { get; set; }
    }
}
