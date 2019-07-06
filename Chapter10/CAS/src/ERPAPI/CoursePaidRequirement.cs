using ERPAPI.Controllers;
using Microsoft.AspNet.Authorization;
using System.Threading.Tasks;

namespace ERPAPI
{
    public class CoursePaidRequirement : Microsoft.AspNetCore.Authorization.IAuthorizationRequirement
    {
        public CoursePaidRequirement()
        {
        }
        public class CoursePaidHandler : Microsoft.AspNetCore.Authorization.AuthorizationHandler<CoursePaidRequirement>
        {
            protected override Task HandleRequirementAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext context, CoursePaidRequirement requirement)
            {

                 Course course=(Course) context.Resource;
                if (course.IsPaid)
                {
                    context.Succeed(requirement);
                }
                
                return Task.CompletedTask;

            }
        }
    }
}