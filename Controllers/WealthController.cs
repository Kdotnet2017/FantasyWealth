using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FantasyWealth.Areas.Identity.Data;
using FantasyWealth.Utilities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FantasyWealth.Controllers
{
    [Authorize]
    public class WealthController : Controller
    {
        private readonly FantasyWealthIdentityDbContext _context;
        private readonly UserManager<FantasyWealthUser> _userManager;
        private readonly TradeHelperService _tradeHelperService;
        //constructor injection to get a dependency.
        public WealthController(
            FantasyWealthIdentityDbContext context,
            UserManager<FantasyWealthUser> userManager,
            TradeHelperService tradeHelperService)
        {
            _context = context;
            _userManager = userManager;
            _tradeHelperService = tradeHelperService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string userId = _userManager.GetUserId(HttpContext.User);
            var wealth = await _context.Wealths
                .Include(w => w.Symbol)
                .Include(w => w.User)
                .Where(w => w.UserId == userId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wealth == null)
            {
                return NotFound();
            }

            return View(wealth);
        }
    }
}