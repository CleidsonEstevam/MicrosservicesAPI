namespace ServiceWeb.CartAPI.Model.Entities
{
    public class Cart
    {
        public CartHeader CartHeader { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
