using BusinessLogic.Models;

namespace BusinessLogic.Contracts
{
    public interface IOrderService
    {
        Task<Order> CurrentOrder(string userName);
        Task<bool> FinishOrder(string userName, float rating);
        Task UpdateOrder(string userName, Recipe? recipe, int quantity = 1);
    }
}