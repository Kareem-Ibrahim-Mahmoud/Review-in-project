namespace Financial_Stock.Model
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
