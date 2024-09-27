using Financial_Stock.Model;

namespace Financial_Stock.Services
{
    public class OrderLogsReposatry : IOrderLogsReposatry
    {

        private Context context;
        

        public OrderLogsReposatry(Context _context)
        {
            context = _context;

        }

        public List<OrderAuditLog> getAll()
        {
            return context.Log.ToList();

        }

        public OrderAuditLog getbyId(int id)
        {
            return context.Log.FirstOrDefault(s=>s.Id == id);

        }
        public int Create(OrderAuditLog orderlog)
        {
            context.Log.Add(orderlog);
            return context.SaveChanges();
        }


        public int update(int id, OrderAuditLog log)
        {
            OrderAuditLog loog = context.Log.FirstOrDefault(s=>s.Id == id);         
            loog.Quantity = log.Quantity;
            loog.ExecutedQuantity = log.ExecutedQuantity;
            loog.Price = log.Price;
            loog.TimeOfLastModification = log.TimeOfLastModification;
            loog.TimeOfSubmission = log.TimeOfSubmission;
            loog.Stock=log.Stock;
            loog.AverageExecutionPrice = log.AverageExecutionPrice;
            int raw = context.SaveChanges();
            return raw;

        }

        public int Delete(int id)
        {
            OrderAuditLog log = context.Log.FirstOrDefault(s=>s.Id == id);
            context.Log.Remove(log);
            
            int raw = context.SaveChanges();
            return raw;


        }
    }
}
