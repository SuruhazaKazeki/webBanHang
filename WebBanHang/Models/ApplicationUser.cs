using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webBanHang.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { set; get; }
        public DateTime Birthday { get; set; }
    }
}
