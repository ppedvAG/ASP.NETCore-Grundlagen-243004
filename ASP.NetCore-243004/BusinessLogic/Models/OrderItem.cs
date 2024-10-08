using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class OrderItem
    {
        [Key]
        public int ItemId { get; set; }

        public Recipe? Recipe { get; set; }

        public int Quantity { get; set; }

        public float Rating { get; set; }
    }
}
