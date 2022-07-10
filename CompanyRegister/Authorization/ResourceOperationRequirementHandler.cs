using CompanyRegister.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CompanyRegister.Authorization
{
	public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Company>
    {
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Company company)
            {
                if (requirement.ResourceOperation == ResourceOperation.Read || requirement.ResourceOperation == ResourceOperation.Create)
                {
                    context.Succeed(requirement);
                }

                var userId = context.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
                if (company.CreatedById == int.Parse(userId))
                {
                    context.Succeed(requirement);
                }

                return Task.CompletedTask;
            }
     }
}
