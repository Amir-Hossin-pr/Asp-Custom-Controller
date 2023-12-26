using Fteam.AspCustomController;
using Microsoft.AspNetCore.Mvc;

namespace Fteam.CostumController.Test.Controllers;

[ApiController, FteamAuth]
[Route("[controller]")]
public class TestController : FteamController
{

    [HttpGet("SayHello")]
    public IActionResult SayHello()
    {
        var user = FtmUser;
        return Ok(new
        {
            user
        });
    }
}
