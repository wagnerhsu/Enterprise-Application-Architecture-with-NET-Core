using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ERPAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class VendorManagementController : Controller
    {
     
        [HttpGet]
        public IEnumerable<Vendor> GetVendors()
        {
            //Returning static values
            return new List<Vendor>
            {
                new Vendor { VendorID=1, Name="Bentley", Email="john@bent.com", PhoneNo="+12012020030", Website="www.bentley.com" },
                new Vendor { VendorID=2, Name="Mercedez", Email="william@benz.com", PhoneNo="+1201203300", Website="www.mercedez.com" },
                new Vendor { VendorID=3, Name="BMW", Email="scott@bmw.com", PhoneNo="+12014500030", Website="www.bmw.com" },
                new Vendor { VendorID=4, Name="Lamborghini", Email="tyson@lamborghini.com", PhoneNo="+12022220030", Website="www.lamborghini.com" },
                new Vendor { VendorID=5, Name="Nissan", Email="george@nissan.com", PhoneNo="+13312020030", Website="www.nissan.com" }

            };
            
        }

        
        // GET api/values/5
        [HttpGet("{id}")]
        public Vendor GetVendor(int id)
        {
            //do something and return vendor
            return null;
        }

        [HttpPost]
        public int CreateVendor(Vendor vendor)
        {
            //to create vendor
            return 0;
        }


        [HttpPut]
        public int UpdateVendor(Vendor vendor)
        {
            //to update vendor
            return 0;
        }


        [HttpDelete]
        public int DeleteVendor(int vendorID)
        {
            //to delete vendor
            return 0;
        }


    }
}
