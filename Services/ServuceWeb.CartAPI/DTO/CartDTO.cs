namespace ServiceWeb.CartAPI.DTO
{
    public class CartDTO
    {
        public CartHeaderDTO CartHeader { get; set; }
        public IEnumerable<CartItemDTO> CartItems { get; set; }

    }
}
