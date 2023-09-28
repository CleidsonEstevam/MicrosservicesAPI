namespace ServiceWeb.CartAPI.Model.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;
        public int CartHeaderId { get; set; }
        public CartHeader CartHeader { get; set; }
        public int ProductCode { get; set; }
        public Product Product { get; set; } = new Product();
    }
}
