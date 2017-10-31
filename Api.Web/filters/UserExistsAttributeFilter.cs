using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

internal class UserExistsAttributeFilter : IAsyncActionFilter
{
    private readonly IManager<User> _userManager;

    public UserExistsAttributeFilter(IManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ActionArguments.ContainsKey("firstname"))
        {
            var firstName = context.ActionArguments["firstname"] as string;
            if (firstName != null)
            {
                if (!_userManager.Exists(firstName))
                {
                    context.Result = new NotFoundObjectResult(firstName);
                    return;
                }
            }
        }
        await next();
    }
}