using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entitise;
using Talabat.Core.Repositories.Contrect;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepositorty<T> where T : BaseEntity
    {
        private readonly StoreContext _dbcontext; 
        public GenericRepository(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public  async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
            {
                return(IEnumerable<T>) await _dbcontext.Set<Product>().Include(P=>P.brand).Include(P=>P.category).ToListAsync();
            }

            return await _dbcontext.Set<T>().ToListAsync();
        }
        public async Task<T> GetAsync(int id)
        {
           return await _dbcontext.Set<T>().FindAsync(id);
        }

    }
}
