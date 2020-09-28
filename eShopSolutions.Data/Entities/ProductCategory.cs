﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolutions.Data.Entities
{
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
