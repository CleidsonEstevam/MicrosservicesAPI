using ServiceWeb.OrderAPI.Model.Base;

namespace ServiceWeb.OrderAPI.Model
{
    public class OrderHeader : BaseEntity
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

        public OrderHeader() {}

        public OrderHeader(string userId, decimal purchaseAmount, string firstName, string lastName, 
            DateTime dateOrder, string cardNumber, string cVV, string expiryMonthYear,
            int cartTotalItens, List<OrderDetail> orderDetails, int paymentStatus)
        {
            UserId = userId;
            PurchaseAmount = purchaseAmount;
            FirstName = firstName;
            LastName = lastName;
            DateOrder = dateOrder;
            CardNumber = cardNumber;
            CVV = cVV;
            ExpiryMonthYear = expiryMonthYear;
            CartTotalItens = cartTotalItens;
            OrderDetails = orderDetails;
            PaymentStatus = paymentStatus;
        }
    }

}
