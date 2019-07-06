using IdentityEmptyProject.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityEmptyProject.Entities
{

    public class UserProfile
    {
        [Key]
        public long UserProfileID { get; set; }
        public bool IsActive { get; set; }
        public int DesignationID { get; set; }
        public Designation Designation { get; set; }
        public int OrganizationID { get; set; }
        public Organization Organization { get; set; }

        public DateTime EffectiveDate { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }

    }

    public class Designation
    {
        [Key]
        public int DesignationID { get; set;}
        public string DesgName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    public class Organization
    {
        [Key]
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PoBoxNo { get; set; }
        public string Website { get; set; }
        public bool IsActive { get; set; }
        public List<Designation> Designations { get; set; }
    }

        
}
