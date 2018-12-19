using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using FantasyWealth.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using FantasyWealth.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FantasyWealth.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
         private readonly UserManager<FantasyWealthUser> _userManager;
        private readonly FantasyWealthIdentityDbContext _context;
        public ScheduleController(
            FantasyWealthIdentityDbContext context,
            UserManager<FantasyWealthUser> userManager)
        {
            //constructor injection to get a dependency.
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
             string userId = _userManager.GetUserId(HttpContext.User);
            var TradeDbContext = _context.Offers.Include(t => t.Symbol).Include(t => t.User)
            .Where(t => t.UserId == userId);
            return View(await TradeDbContext.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create( string SymbolId,string CurrentPrice,string Shares)
        {
            if (string.IsNullOrWhiteSpace(SymbolId))
            {
                ViewData["SymbolId"] = new SelectList(_context.TickerSymbols.OrderBy(s => s.Symbol).Where(s => s.isEnabled == true), "Id", "Symbol");
            }
            else
            {
                ViewData["SymbolId"] = new SelectList(_context.TickerSymbols.OrderBy(s => s.Symbol).Where(s => s.isEnabled == true && s.Id == int.Parse(SymbolId)), "Id", "Symbol");
                ViewData["CurrentPrice"] = CurrentPrice;
                ViewData["Quantity"]=Shares;
            }
            return View();
        }
         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,SymbolId,CurrentPrice,OfferPrice,Action,ExpirationDate,CreationDate,UpdatedDate,Expired")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                offer.UserId = _userManager.GetUserId(HttpContext.User);
                offer.CreationDate = DateTime.Now;
                offer.UpdatedDate=DateTime.Now;
                _context.Add(offer);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["SymbolId"] = new SelectList(_context.TickerSymbols.Where(s => s.isEnabled == true), "Id", "Symbol", offer.SymbolId);
            return View(offer);
        }

    }
}