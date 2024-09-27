using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_Stock.Model
{
    public class OrderAuditLog
    {
        public int Id { get; set; }

        [ForeignKey("orders")]
        public int orderid { get; set; }
        public virtual Orders orders { get; set; }
        public string ActionType { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        [Required]
        public DateTime TimeOfSubmission { get; set; } //send
        [Required]
        public DateTime TimeOfLastModification { get; set; } //time update
        [Required]
        public decimal ExecutedQuantity { get; set; }
        [Required]
        public decimal AverageExecutionPrice { get; set; }


        public Stock Stock { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
