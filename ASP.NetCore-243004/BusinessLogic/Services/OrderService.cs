using BusinessLogic.Data;
using BusinessLogic.Models;
using BusinessLogic.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class OrderService
    {
        private readonly FoodDeliveryDbContext _context;

        public OrderService(FoodDeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CurrentOrder(string userName)
        {
            var order = await GetPendingOrderByUserName(userName);

            if (order == null)
            {
                order = new Order
                {
                    UserName = userName,
                    Status = OrderStatus.Pending,
                    OrderDate = DateTime.Now,
                    OrderItems = new List<OrderItem>()
                };

                _context.Orders.Add(order);

                await _context.SaveChangesAsync();
            }

            return order;
        }

        private Task<Order?> GetPendingOrderByUserName(string userName)
        {
            return _context.Orders.FirstOrDefaultAsync(o => o.UserName == userName && o.Status == OrderStatus.Pending);
        }

        public async Task<bool> FinishOrder(string userName, float rating)
        {
            var order = await GetPendingOrderByUserName(userName);

            if (order != null)
            {
                order.Rating = rating;
                order.Status = OrderStatus.Done;
                _context.Update(order);

                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task UpdateOrder(string userName, Recipe? recipe, int quantity = 1)
        {
            var order = await CurrentOrder(userName);
            order.OrderItems.Add(new OrderItem
            {
                Recipe = recipe,
                Quantity = quantity
            });

            await _context.SaveChangesAsync();
        }
    }
}
