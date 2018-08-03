using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FantasyWealth.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using FantasyWealth.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using FantasyWealth.Utilities;

namespace FantasyWealth.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly FantasyWealthIdentityDbContext _context;
        private readonly UserManager<FantasyWealthUser> _userManager;
        private readonly TradeHelperService _tradeHelperService;
        //constructor injection to get a dependency.
        public TransactionController(FantasyWealthIdentityDbContext context, UserManager<FantasyWealthUser> userManager, TradeHelperService tradeHelperService)
        {
            _context = context;
            _userManager = userManager;
            _tradeHelperService = tradeHelperService;
        }
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var TransactionsDbContext = _context.Transactionrs.Include(t => t.Trade).Include(t => t.User)
            .Where(t => t.UserId == userId).OrderBy(t => t.CreationDate);
            return View(await TransactionsDbContext.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create(string TradeIdQS)
        {
            if (string.IsNullOrWhiteSpace(TradeIdQS))
            {
                ViewData["TradeId"] = "";
            }
            else
            {
                ViewData["TradeId"] = TradeIdQS;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TradeId,TransType,FromAccount,ToAccount,TotalAmount,Comment,TimeStamp,Reconciled")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.UserId = _userManager.GetUserId(HttpContext.User);
                transaction.CreationDate = DateTime.Now;
                transaction.Reconciled = true;
                _context.Add(transaction);
                await _context.SaveChangesAsync();

                bool result = await _tradeHelperService.updateUserCashBalance(transaction);
                if (!result)
                {
                    ViewData["error"] = "Transaction Faild.";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string userId = _userManager.GetUserId(HttpContext.User);
            var transaction = await _context.Transactionrs
                .Include(t => t.Trade)
                .Include(t => t.User)
                .Where(u => u.UserId == userId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }


            // decimal balance= await _tradeHelperService.getUserCashBalance(transaction);
            //  ViewData["Balance"]=balance;
            ViewData["Balance"] = TradeHelperService.readConfigurationSetting("InitialFund");

            return View(transaction);
        }
    }
}