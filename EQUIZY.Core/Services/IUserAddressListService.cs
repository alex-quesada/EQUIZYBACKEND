using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface IUserAddressListService
    {
        Task<UserAddressList> GetUserAddressListItemById(int id);
        Task<UserAddressList> GetUserAddressListByAddressId(int addressId);
        Task<UserAddressList> CreateUserAddressListItem(UserAddressList newUserAddresListItem);
        Task DeleteUserAddressListItem(UserAddressList userAddressList);
    }
}
