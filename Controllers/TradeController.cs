using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FantasyWealth.Models
{
    [Authorize]
    public class TradeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}