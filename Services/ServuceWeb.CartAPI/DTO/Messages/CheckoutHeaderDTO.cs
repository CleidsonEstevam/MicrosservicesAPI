using Service.MessageBus;

namespace ServiceWeb.CartAPI.DTO.Messages
{
    public class CheckoutHeaderDTO : BaseMessage
    {
        public string UserId { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOrder { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryMothYear { get; set; }
        public int CartTotalItens { get; set; }
        public IEnumerable<CartItemDTO> CartItems { get; set; }
    }
}
