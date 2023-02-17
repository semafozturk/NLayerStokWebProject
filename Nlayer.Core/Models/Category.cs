using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core
{
    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
