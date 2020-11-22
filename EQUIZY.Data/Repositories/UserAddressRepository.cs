using EQUIZY.Core.Models;
using EQUIZY.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Data.Repositories
{
    public class UserAddressRepository : Repository<UserAddressList>, IUserAddressListRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public UserAddressRepository(MyEquizyDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<UserAddressList>> GetAllUserAddressListAsync(AppUser appUser)
        {
            return await MyEquizyDbContext
                .UserAddressList
                .Where(m => m.UserId == appUser.Id)
                .Where(m => m.Status < 2).ToListAsync();
        }

        public async Task<UserAddressList> GetUserAddressListItemByIdAsync(int id)
        {
            return await MyEquizyDbContext.UserAddressList.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<UserAddressList> GetUserAddressListItemByAddressAsync(int addressId)
        {
            return await MyEquizyDbContext.UserAddressList.SingleOrDefaultAsync(a => a.AddressId == addressId);
        }
    }
}
