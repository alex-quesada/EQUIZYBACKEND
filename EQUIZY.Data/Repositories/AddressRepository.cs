using EQUIZY.Core.Models;
using EQUIZY.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public AddressRepository(MyEquizyDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<Address>> GetAllWithCityAsync(Guid id)
        {
            var result = new List<Address>();
            var addressListItems = await MyEquizyDbContext
                                        .UserAddressList
                                        .Where(m => m.UserId == id)
                                        .ToListAsync();
            foreach (var addItem in addressListItems)
            {
                if (addItem.Status < 2)
                {
                    var address = await MyEquizyDbContext
                                        .Addresses
                                        .Include(m => m.City)
                                        .SingleOrDefaultAsync(m => m.Id == addItem.AddressId);
                    result.Add(address);
                }
            }
            return result;
        }

        public async Task<Address> GetWithCityByIdAsync(int id)
        {
            return await MyEquizyDbContext.Addresses.Include(m => m.City).SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}
