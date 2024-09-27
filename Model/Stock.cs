using System.ComponentModel.DataAnnotations;

namespace Financial_Stock.Model
{
    public class Stock
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string StockSymbol { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
