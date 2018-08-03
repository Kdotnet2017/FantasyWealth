using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FantasyWealth.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}