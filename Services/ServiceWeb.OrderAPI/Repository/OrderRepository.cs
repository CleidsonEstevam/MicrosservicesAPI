using ServiceWeb.OrderAPI.Model;
using ServiceWeb.OrderAPI.Model.Context;
using ServiceWeb.OrderAPI.Repository.Interface;

namespace ServiceWeb.OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly MySQLContext _context;

        public OrderRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOrder(OrderHeader header)
        {
            if (header == null) return false;

            _context.OrderHeaders.Add(header);

            await _context.SaveChangesAsync();

            return true;
        }

        public Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid)
        {
            throw new NotImplementedException();
        }
    }
}
