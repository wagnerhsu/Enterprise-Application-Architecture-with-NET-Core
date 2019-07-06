using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ERPAPI.Controllers
{
    public class Employee
    {
    }

    public class BaseLocationRequirement : Microsoft.AspNetCore.Authorization.IAuthorizationRequirement
    {
        public BaseLocationRequirement(List<string> locations)
        {
            BaseLocation = locations;
        }

        public List<string> BaseLocation { get; set; }
    }

    public class BaseLocationHandler : Microsoft.AspNetCore.Authorization.AuthorizationHandler<BaseLocationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BaseLocationRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Country))
            {
                return Task.CompletedTask;
            }

            string country = context.User.FindFirst(c => c.Type == ClaimTypes.Country).Value;

            List<string> gccCountries = requirement.BaseLocation;

            if (gccCountries.Contains(country))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;

        }


    }
}