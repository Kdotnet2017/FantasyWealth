using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FantasyWealth.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using FantasyWealth.Models;

namespace FantasyWealth.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<FantasyWealthUser> _userManager;
        private readonly FantasyWealthIdentityDbContext _context;
        public DashboardController(FantasyWealthIdentityDbContext context, UserManager<FantasyWealthUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var wealthDbContext = _context.Wealths.Include(w => w.Symbol).Include(w => w.User)
             .Where(t => t.UserId == userId).OrderByDescending(w => w.UpdatedDate);
            var TransactionsDbContext = _context.Transactions.Include(t => t.Trade).Include(t => t.User)
            .Where(t => t.UserId == userId).OrderBy(t => t.CreationDate).Take(5).OrderByDescending(t => t.CreationDate);
            var TradeDbContext = _context.Trades.Include(t => t.Symbol).Include(t => t.User)
            .Where(t => t.UserId == userId).Take(5).OrderByDescending(t => t.CreationDate);
            DashboardVM dashboardVM = new DashboardVM();
            dashboardVM.Wealths = await wealthDbContext.ToListAsync();
            dashboardVM.Transactions = await TransactionsDbContext.ToListAsync();
            dashboardVM.Trades = await TradeDbContext.ToListAsync();
            return View(dashboardVM);
        }
    }
}