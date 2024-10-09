using BusinessLogic.Contracts;
using DemoMvcApp.Data;
using DemoMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AccountDbContext _context;
        private readonly IOrderService _orderService;

        public DashboardController(AccountDbContext context, IOrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            string name = HttpContext.User.Identity.Name;
            var model = new DashboardViewModel
            {
                UserName = name,
                CurrentOrder = await _orderService.CurrentOrder(name)
            };

            return View(model);
        }
    }
}
