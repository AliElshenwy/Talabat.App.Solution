﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entitise
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public string PictureUrl  { get; set; }
        public decimal Price  { get; set; }

        public int BrandId { get; set; } //FK
        public ProductBrand brand { get; set; }
        public int CategoryId  { get; set; }
        public ProductCategory category { get; set; }


    }
}
