using BusinessLogic.Models;

namespace DemoMvcApp.Models
{
    public class DashboardViewModel
    {
        public string UserName { get; set; }

        public Order CurrentOrder { get; set; }

        public List<Order> Orders { get; set; }
    }
}
