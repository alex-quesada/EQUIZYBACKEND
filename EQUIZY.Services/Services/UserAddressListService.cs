using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class UserAddressListService : IUserAddressListService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserAddressListService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<UserAddressList> CreateUserAddressListItem(UserAddressList newUserAddresListItem)
        {
            await _unitOfWork.UserAddressList
                .AddAsync(newUserAddresListItem);
            await _unitOfWork.CommitAsync();
            return newUserAddresListItem;
        }

        public async Task DeleteUserAddressListItem(UserAddressList userAddressList)
        {
            var addressDelete = await GetUserAddressListItemById(userAddressList.Id);
            addressDelete.Status = 2;
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<UserAddressList>> GetAllUserAddressListItems(AppUser appUser)
        {
            return await _unitOfWork.UserAddressList.GetAllUserAddressListAsync(appUser);
        }

        public async Task<UserAddressList> GetUserAddressListByAddressId(int addressId)
        {
            return await _unitOfWork.UserAddressList.GetUserAddressListItemByAddressAsync(addressId);
        }

        public async Task<UserAddressList> GetUserAddressListItemById(int id)
        {
            return await _unitOfWork.UserAddressList.GetByIdAsync(id);
        }
    }
}
