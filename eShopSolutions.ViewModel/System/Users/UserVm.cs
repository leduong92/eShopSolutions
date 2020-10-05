using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolutions.ViewModel.System.Users
{
    public class UserVm
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string  UserName { get; set; }
        public string Email { get; set; }
    }
}
