using IdentityEmptyProject.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace IdentityEmptyProject.Data
{
    public class ApplicationUser : IdentityUser
    {

        public List<UserProfile> UserProfiles { get; set; }
        public string TwitterHandler { get; set; }
        public string LinkedInProfileLink { get; set; }
        public string SkypeAccount { get; set; }
    }
}