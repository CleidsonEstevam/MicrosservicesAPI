namespace ServiceWeb.CartAPI.Model.Entities
{
    public class Cart
    {
        public CartHeader CartHeader { get; private set; }
        public IEnumerable<CartItem> CartItems { get; private set; }



        public void ChangeCartHeader(CartHeader cartHeader)
        {
            CartHeader = cartHeader;
        }

        public void ChangeCartItem(List<CartItem> cartItem)
        {
            CartItems = cartItem;
        }


        public void ChangeUserId(string userId)
        {
            CartHeader.UserId = userId;
        }


        public void ChangeQuantity(int quantity)
        {
            CartItems.FirstOrDefault().Quantity = quantity;
        }
        public void ChangeProductCodey(string productCode)
        {
            CartItems.FirstOrDefault().ProductCode = productCode;
        }
        public void ChangeCartHeaderId(long cartHeaderId)
        {
            CartItems.FirstOrDefault().CartHeaderId = cartHeaderId;
        }

    }
}
