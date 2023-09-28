namespace ServiceWeb.CartAPI.Model.Entities
{
    public class CartHeader
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string CouponCode { get; set; } = string.Empty;
        public ICollection<CartItem> CartItems { get; set; }


        public CartHeader()
        {
                
        }
    }


}
