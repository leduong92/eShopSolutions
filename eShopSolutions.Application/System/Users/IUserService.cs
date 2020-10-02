using eShopSolutions.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutions.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginRequset request);

        Task<bool> Register(RegisterRequest request);
    }
}