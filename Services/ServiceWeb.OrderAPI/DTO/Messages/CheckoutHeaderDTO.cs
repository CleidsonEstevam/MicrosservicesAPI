using ServiceWeb.OrderAPI.Model;

namespace ServiceWeb.OrderAPI.DTO.Messages
{
    public class CheckoutHeaderDTO
    {
        public string UserId { get; set; }

        public decimal PurchaseAmount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOrder { get; set; }

        public string CardNumber { get; set; }

        public string CVV { get; set; }

        public string ExpiryMonthYear { get; set; }

        public int CartTotalItens { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public int PaymentStatus { get; set; }

    }
}
