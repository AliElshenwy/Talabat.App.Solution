using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entitise;

namespace Talabat.Core.Repositories.Contrect
{
    public  interface IGenericRepositorty<T> where T : BaseEntity
    {
        Task<T> GetAsync(int id );
        Task<IEnumerable<T>> GetAllAsync();

    }
}
