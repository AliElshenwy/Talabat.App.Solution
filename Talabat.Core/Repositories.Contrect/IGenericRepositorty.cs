using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entitise;
using Talabat.Core.Specifications;

namespace Talabat.Core.Repositories.Contrect
{
    public  interface IGenericRepositorty<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec);
        Task<T> GetAsyncWithSpecAsync(ISpecification<T> spec);


    }
}
