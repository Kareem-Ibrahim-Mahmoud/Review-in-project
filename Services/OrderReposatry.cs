using Financial_Stock.Model;

namespace Financial_Stock.Services
{
    public class OrderReposatry : IOrderReposatry
    {
        private Context context;

       public OrderReposatry(Context _context)
        {
            context = _context;

        }

        public List<Orders> getAll()
        {
            return context.orders.ToList();
        }

        public Orders getbyid(int id)
        {
            return context.orders.FirstOrDefault(s => s.Id == id);


        }


        public int Create(Orders order)
        {
            context.orders.Add(order);

            return context.SaveChanges();
        }

        public int Update(int id,Orders orderr)
        {
            Orders order = context.orders.FirstOrDefault(s => s.Id == id);  

            order.Name = orderr.Name;
            order.Price = orderr.Price;
            order.Quantity = orderr.Quantity;
            order.TimeOfLastModification = orderr.TimeOfLastModification;
            order.TimeOfSubmission = orderr.TimeOfSubmission;
            order.AverageExecutionPrice = orderr.AverageExecutionPrice; 
            order.Created_At=orderr.Created_At;
            order.ExecutedQuantity = orderr.ExecutedQuantity;

            int raw =context.SaveChanges();
            return raw;

        }


        public int Delete(int id)
        {
            Orders order =context.orders.FirstOrDefault(s => s.Id == id);
            context.orders.Remove(order);
            int raw =context.SaveChanges();
            return raw;


        }


    }
}
