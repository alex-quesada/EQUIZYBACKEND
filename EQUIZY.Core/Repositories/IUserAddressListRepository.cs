using EQUIZY.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface IUserAddressListRepository : IRepository<UserAddressList>
    {
        Task<IEnumerable<UserAddressList>> GetAllUserAddressListAsync(AppUser appUser);
        Task<UserAddressList> GetUserAddressListItemByIdAsync(int id);
        Task<UserAddressList> GetUserAddressListItemByAddressAsync(int addressId);
    }
}
