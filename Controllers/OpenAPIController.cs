using System;
using System.Collections.Generic;
using FantasyWealth.Models;
using Microsoft.AspNetCore.Mvc;
using FantasyWealth.Utilities;
using FantasyWealth.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyWealth.Controllers
{
    public class OpenAPIController : Controller
    {
        private readonly FantasyWealthIdentityDbContext _context;
        public OpenAPIController(FantasyWealthIdentityDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<string>> getSymbolAutocomplete(string txtSymbol)
        {
            var symbols = from m in _context.TickerSymbols
                          orderby m.Symbol
                          where m.Symbol.Contains(txtSymbol)
                          select m.Symbol;
            return (await symbols.ToListAsync());
        }
        [HttpGet]
        public IActionResult getPrice(string SearchSymbol)
        {
            var price = iexTrading.getSymbolPrice(SearchSymbol);
            ViewData["Price"] = price;
            return PartialView("getPrice");
        }
        [HttpGet]
        public string getSymbolPrice(string SearchSymbol)
        {
            var price = iexTrading.getSymbolPrice(SearchSymbol);
            return price;
        }
        /*  public string getDateTime()
          {
              var todayDate = DateTime.Now.ToString();
              return todayDate;
          }*/
        /*   public async Task<IActionResult> getMultiChartAsync(string[] arrSearchSymbol)
           {
               // Next version.
               return  PartialView("");
           }*/
        public IActionResult getChart(string SearchSymbol)
        {
            return PartialView("getChart");
        }
        public IActionResult getInfo(string SearchSymbol)
        {
            CompanyVM coVM = new CompanyVM();
            coVM = getCompanyInfoAsVM(SearchSymbol);
            return PartialView("getInfo", coVM);
        }
        public JsonResult getChartDataAsJson(string SearchSymbol)
        {
            List<ChartVM> lChart = new List<ChartVM>();
            lChart = iexTrading.getSymbolChart(SearchSymbol);
            return Json(lChart);
        }
        public JsonResult getCompanyInfoAsJson(string SearchSymbol)
        {
            CompanyVM companyInfo = new CompanyVM();
            companyInfo = iexTrading.getSymbolCompany(SearchSymbol);
            return Json(companyInfo);
        }
        public CompanyVM getCompanyInfoAsVM(string SearchSymbol)
        {
            CompanyVM companyInfo = new CompanyVM();
            companyInfo = iexTrading.getSymbolCompany(SearchSymbol);
            return companyInfo;
        }
    }
}