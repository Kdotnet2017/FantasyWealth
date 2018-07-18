using System;
using System.Collections.Generic;
using FantasyWealth.Models;
using Microsoft.AspNetCore.Mvc;
using FantasyWealth.Utilities;

namespace FantasyWealth.Controllers
{
    public class OpenAPIController : Controller
    {
        [HttpGet]
        public IActionResult getPrice(string SearchSymbol)
        {
            var price = iexTrading.getSymbolPrice(SearchSymbol);
            ViewData["Price"] = price;
            return PartialView("getPrice");
        }
        public IActionResult getChart(string SearchSymbol)
        {
            return PartialView("getChart");
        }
      
        public JsonResult getData(string SearchSymbol)
        {
            List<ChartVM> lChart = new List<ChartVM>();
            lChart = iexTrading.getSymbolChart(SearchSymbol);
            return Json(lChart);
        }
    }
}