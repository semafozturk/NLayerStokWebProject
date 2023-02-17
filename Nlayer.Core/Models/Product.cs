using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public decimal purchasePrice { get; set; }
        public decimal salePrice { get; set; }
        public int stock { get; set; }
        public int categoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
