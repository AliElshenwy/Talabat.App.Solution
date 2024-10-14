using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entitise;

namespace Talabat.Core.Specifications
{
    public interface ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Critria { get; set; }  // P=>P.id ==Id 
        public List<Expression<Func<T,object>>> Includes { get; set; }  // {P=.P.Brand,P=>P.catgory} 
    }
}
