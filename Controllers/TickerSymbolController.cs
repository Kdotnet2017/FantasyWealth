using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FantasyWealth.Models;
using FantasyWealth.Utilities;
using System.Threading.Tasks;
using FantasyWealth.Areas.Identity.Data;
using System.Linq;

namespace FantasyWealth.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TickerSymbolController : Controller
    {
        private readonly FantasyWealthIdentityDbContext _context;
        public TickerSymbolController(FantasyWealthIdentityDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            await createSymbols();

            return View("Index");
        }
        public IActionResult Update()
        {

            updateSymbols().Wait();

            return View("Index");
        }
        private async Task createSymbols()
        {
            List<SymbolVM> lSymbolVM = new List<SymbolVM>();
            lSymbolVM = await iexTrading.getTickerSymbolListAsync();
            ViewData["message"] = "# of Symbols Inserted : " + lSymbolVM.Count.ToString();
            List<TickerSymbol> lTickerSymbol = new List<TickerSymbol>();
            foreach (var symbol in lSymbolVM)
            {
                bool tempBool;
                DateTime tempDateTime;
                TickerSymbol tickerSymbol = new TickerSymbol();
                tickerSymbol.Symbol = symbol.symbol;
                tickerSymbol.Name = symbol.name;
                tickerSymbol.isEnabled = (Boolean.TryParse(symbol.isEnabled, out tempBool)) ? tempBool : false;
                tickerSymbol.CreationDate = (DateTime.TryParse(symbol.date, out tempDateTime)) ? tempDateTime : DateTime.Now;
                lTickerSymbol.Add(tickerSymbol);
            }
            _context.AddRange(lTickerSymbol);
            _context.SaveChanges();
        }
        private async Task updateSymbols()
        {
            List<SymbolVM> lSymbolVM = new List<SymbolVM>();
            lSymbolVM = await iexTrading.getTickerSymbolListAsync();

            List<TickerSymbol> lTickerSymbol = new List<TickerSymbol>();
            List<TickerSymbol> lTickerSymbolToUpdate = new List<TickerSymbol>();
            List<TickerSymbol> templTickerSymbolToUpdate = new List<TickerSymbol>();
            var tempListSymbol = _context.TickerSymbols.ToList();
            // checking for new symbol and updated symbol. Do research on thisfor a better way to do.
            foreach (var symbol in lSymbolVM)
            {
                bool tempBool;
                DateTime tempDateTime;
                TickerSymbol tickerSymbol = new TickerSymbol();
                tickerSymbol.Symbol = symbol.symbol;
                tickerSymbol.Name = symbol.name;
                tickerSymbol.isEnabled = (Boolean.TryParse(symbol.isEnabled, out tempBool)) ? tempBool : false;
                tickerSymbol.CreationDate = (DateTime.TryParse(symbol.date, out tempDateTime)) ? tempDateTime : DateTime.Now;
                if (tempListSymbol.Contains(tickerSymbol, new SymbolNewRecordComparer()))
                {
                    if (tempListSymbol.Contains(tickerSymbol, new SymbolEqualityComparer()))
                    {
                        //do nothing
                    }
                    else
                    {
                        // update the data
                        lTickerSymbolToUpdate.Add(tickerSymbol);
                    }
                }
                else
                {
                    // insert a new symbol
                    lTickerSymbol.Add(tickerSymbol);
                }
            }
            _context.AddRange(lTickerSymbol);
            int i = _context.SaveChanges();
            ViewData["message"] = "# of New Symbols Inserted : " + i.ToString();
        }
    }
}