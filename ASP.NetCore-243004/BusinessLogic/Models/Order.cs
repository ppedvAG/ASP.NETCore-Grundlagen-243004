using BusinessLogic.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string UserName { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public OrderStatus Status { get; set; }

        public float Rating { get; set; }
    }
}
