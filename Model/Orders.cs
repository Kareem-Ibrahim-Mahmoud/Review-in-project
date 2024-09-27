using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_Stock.Model
{
    public class Orders
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid ClientOrderID { get; set; }
        [ForeignKey("Stock")]
        public int StockID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime TimeOfSubmission { get; set; } //send
        [Required]
        public DateTime TimeOfLastModification { get; set; } //time update
        [Required]
        public decimal ExecutedQuantity { get; set; }
        [Required]
        public decimal AverageExecutionPrice { get; set; }

        [Required]
        public DateTime Created_At { get; set; } //create 

        public ApplicationUser User { get; set; }
        public Stock Stock { get; set; }

        [ForeignKey("OrderStatus")]
        public int idorderstatus { get; set; }
        public OrderStatus OrderStatus { get; set; }

    }
}
