﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolutions.ViewModel.System.Users
{
    public class LoginRequset
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}