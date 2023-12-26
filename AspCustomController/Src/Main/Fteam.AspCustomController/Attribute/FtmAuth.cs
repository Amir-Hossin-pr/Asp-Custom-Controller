using Identity.Client.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using static Fteam.AspCustomController.Constant;

namespace Fteam.AspCustomController;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class FteamAuthAttribute : ControllerAttribute, IAsyncActionFilter
{
    private IUser? _user;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        SetDependencies(context.HttpContext);

        FteamController? controller = context.Controller as FteamController;
        await FindUserAndSetToController(context.HttpContext, controller);

        await next();
    }

    void SetDependencies(HttpContext httpContext)
    {
        _user = httpContext.RequestServices.GetService<IUser>();
    }

    async Task FindUserAndSetToController(HttpContext context, FteamController? controller)
    {
        if (controller is null || _user is null)
            return;

        IHeaderDictionary headers = context.Request.Headers;
        var user = await _user.FindUserWithTokenAsync(headers[AuthToken]);
        if (user is not null)
            controller.FtmUser = user;
    }
}
