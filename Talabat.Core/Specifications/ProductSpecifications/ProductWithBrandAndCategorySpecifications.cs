using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entitise;

namespace Talabat.Core.Specifications.ProductSpecifications
{
    public class ProductWithBrandAndCategorySpecifications:BaseSpecification<Product>
    {
        public ProductWithBrandAndCategorySpecifications():base()
        {
            Includes.Add(P => P.brand);
            Includes.Add(P => P.category);

        }

        public ProductWithBrandAndCategorySpecifications(int id) :base(P=>P.Id==id)
        {
            Includes.Add(P => P.brand);
            Includes.Add(P => P.category);
        }
        

    }
}
