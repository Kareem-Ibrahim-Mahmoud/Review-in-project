using Financial_Stock.Model;

namespace Financial_Stock.Services
{
    public interface IStockReposatry
    {
        public List<Stock> getall();
        public Stock getbyId(int id);
        public int Create(Stock stock);
        public int update(int id, Stock stock);
        public int Delete(int id);
    }
}
