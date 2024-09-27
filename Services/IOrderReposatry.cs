using Financial_Stock.Model;

namespace Financial_Stock.Services
{
    public interface IOrderReposatry
    {
        public List<Orders> getAll();

        public Orders getbyid(int id);
        public int Create(Orders order);

        public int Update(int id, Orders orderr);

        public int Delete(int id);




    }
}
