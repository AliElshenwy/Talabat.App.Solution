using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entitise;
using Talabat.Core.Specifications;

namespace Talabat.Repository
{
    internal class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InnerQurey,ISpecification<TEntity> spec)
        {
            var query = InnerQurey; 
            if (spec.Critria is not null)  //_dbcontext.Set<Product>()
            {
                query= query.Where(spec.Critria); // _dbcontext.Set<Product>().where(P=>P.Id==Id)
            }

            //spec.Include = [p=>p.brand ,p=>p.category]
            //query = spec 
            //currentQiery = InPut
            //includeExprssion = OutPut 

            query= spec.Includes.Aggregate(query,(currentQuery ,includeExpression)=>currentQuery .Include(includeExpression));
                return query;
        }
    }
}
