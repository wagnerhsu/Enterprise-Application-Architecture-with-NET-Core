using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityEmptyProject.Models
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TwitterHandle { get; set; }
        public string LinkedInProfile { get; set; }
        public string SkypeAccount { get; set; }
    }
}
