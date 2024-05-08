using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace MyEshop_Clean.Domain
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; } 
        public string RePassword { get; set; }
    }

    public class LoginViewModel
    { public string Email { get; set; }

      public string Password { get; set; }

       public bool RememberMe { get; set; }
    }
}
