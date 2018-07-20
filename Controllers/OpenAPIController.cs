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
       public IActionResult getInfo(string SearchSymbol)
       {
           CompanyVM coVM=new CompanyVM();
           coVM=getCompanyInfoAsVM(SearchSymbol);
           return PartialView("getInfo",coVM);
       }
        public JsonResult getChartDataAsJson(string SearchSymbol)
        {
            List<ChartVM> lChart = new List<ChartVM>();
            lChart = iexTrading.getSymbolChart(SearchSymbol);
            return Json(lChart);
        }
        public JsonResult getCompanyInfoAsJson(string SearchSymbol)
        {
            CompanyVM companyInfo=new CompanyVM();
            companyInfo=iexTrading.getSymbolCompany(SearchSymbol);
            return Json(companyInfo);
        }
        public CompanyVM getCompanyInfoAsVM(string SearchSymbol)
        {
            CompanyVM companyInfo=new CompanyVM();
            companyInfo=iexTrading.getSymbolCompany(SearchSymbol);
            return companyInfo;
        }
    }
}