using Financial_Stock.Model;

namespace Financial_Stock.Services
{
    public interface IOrderLogsReposatry
    {

        public List<OrderAuditLog> getAll();
        public OrderAuditLog getbyId(int id);
        public int Create(OrderAuditLog orderlog);
        public int update(int id, OrderAuditLog log);
        public int Delete(int id);

    }
}
