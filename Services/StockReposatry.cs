using Financial_Stock.Model;

namespace Financial_Stock.Services
{
    public class StockReposatry : IStockReposatry
    {

        private Context context;
       public StockReposatry(Context _context)
        {
            context = _context;
        }

        public List<Stock> getall()
        {
            return context.stock.ToList();

        }

        public Stock getbyId(int id)
        {
            return context.stock.FirstOrDefault(s=>s.Id==id);
        }
        public int Create(Stock stock)
        {
            context.stock.Add(stock);
            return context.SaveChanges();

        }

        public int update(int id,Stock stock)
        {
            Stock stockToUpdate = context.stock.FirstOrDefault(s=>s.Id==id);
            stockToUpdate.Id = id;
            stockToUpdate.Name = stock.Name;
            stockToUpdate.Orders = stock.Orders;    

            int raw=context.SaveChanges();
            return raw;
        }

        public int Delete(int id)
        {
            Stock stock =context.stock.FirstOrDefault(s=>s.Id==id);
            context.stock.Remove(stock);
            int raw=context.SaveChanges();
            return raw;

        }


    }
}
