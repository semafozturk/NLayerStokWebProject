﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core.DTOs
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public decimal purchasePrice { get; set; }
        public decimal salePrice { get; set; }
        public int stock { get; set; }
        public int categoryId { get; set; }
    }
}
