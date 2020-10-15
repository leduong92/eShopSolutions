using eShopSolutions.ViewModel.Common;
using eShopSolutions.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolutions.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);

        Task<PagedResult<UserVm>> GetUsersPaging(GetUserPagingRequest request);

        Task<bool> RegisterUser(RegisterRequest request);

    }
}
