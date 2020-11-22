using EQUIZY.Core.Models;
using EQUIZY.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Data.Repositories
{
    public class TypeAddressRepository : Repository<TypeAddress>, ITypeAddressRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public TypeAddressRepository(MyEquizyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<TypeAddress>> GetAllTypeAddressAsync()
        {
            return await MyEquizyDbContext.TypesAddress.ToListAsync();
        }

        public async Task<TypeAddress> GetTypesAddressByIdAsync(int id)
        {
            return await MyEquizyDbContext.TypesAddress.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
