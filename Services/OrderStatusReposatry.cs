using Financial_Stock.Model;

namespace Financial_Stock.Services
{
    public class OrderStatusReposatry : IOrderstatusReposatry
    {
        private Context context;

       public OrderStatusReposatry (Context _context)
        {
            context = _context;
        }

        public List<OrderStatus> getall()
        {
            return context.status.ToList();
        }

        public OrderStatus getbyid(int id)
        {
            return context.status.FirstOrDefault(s => s.Id == id);

        }

        public int Create(OrderStatus st)
        {
            context.status.Add(st);
            return context.SaveChanges();


        }

        public int update(int id,OrderStatus stutes)
        {
            OrderStatus stutess=context.status.FirstOrDefault(s=>s.Id == id);

            stutess.Name = stutes.Name;
            stutes.Orders = stutess.Orders;


            int raw= context.SaveChanges();

            return raw;
        }


        public int Delete(int id)
        {
            OrderStatus status=context.status.FirstOrDefault(s=>s.Id == id);

            context.status.Remove(status);

            int raw= context.SaveChanges();

            return raw;

        }

    }
}
