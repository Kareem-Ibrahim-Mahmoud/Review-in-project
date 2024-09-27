using Financial_Stock.Model;

namespace Financial_Stock.Services
{
    public interface IOrderstatusReposatry
    {
        public List<OrderStatus> getall();
        public OrderStatus getbyid(int id);
        public int Create(OrderStatus st);
        public int update(int id, OrderStatus stutes);
        public int Delete(int id);





    }
}
