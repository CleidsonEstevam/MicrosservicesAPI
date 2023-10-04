namespace ServiceWeb.CartAPI.Model.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int CartHeaderId { get; set; }
        public string? ProductCode { get; set; }
        public CartItem(){}
    }
}
