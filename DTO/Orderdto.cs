using Financial_Stock.Model;
using System.ComponentModel.DataAnnotations;

namespace Financial_Stock.DTO
{
    public class Orderdto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid ClientOrderID { get; set; }
       // [ForeignKey("Stock")]
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
        public OrderStatus OrderStatus { get; set; }
    }
}
