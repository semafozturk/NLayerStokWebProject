using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core
{
    public class Purchase
    {
        public int purchaseId { get; set; }
        public int purchasesQuantity { get; set; }
        public DateTime purchaseDate { get; set; }
        public string comment { get; set; }
        public int productId { get; set; }
        public Product Product { get; set; }
    }
}
