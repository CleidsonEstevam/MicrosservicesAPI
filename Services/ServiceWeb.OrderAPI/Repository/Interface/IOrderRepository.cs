using ServiceWeb.OrderAPI.Model;

namespace ServiceWeb.OrderAPI.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader header);
        Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid);
    }
}
