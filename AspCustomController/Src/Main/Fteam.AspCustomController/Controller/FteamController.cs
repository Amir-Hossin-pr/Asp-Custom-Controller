using Identity.Client.Model;
using Microsoft.AspNetCore.Mvc;

namespace Fteam.AspCustomController;

public class FteamController : ControllerBase
{
    public User? FtmUser { get; set; }
}
