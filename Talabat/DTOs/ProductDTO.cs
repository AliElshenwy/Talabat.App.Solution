﻿using Talabat.Core.Entitise;

namespace Talabat.DTOs
{
    public class ProductDTO 
    {

        public  int  Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; } //FK
        public string brand { get; set; }
        public int CategoryId { get; set; }
        public string  category { get; set; }

    }
}
