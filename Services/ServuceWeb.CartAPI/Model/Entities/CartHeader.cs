using System.Collections.Specialized;

namespace ServiceWeb.CartAPI.Model.Entities
{
    public class CartHeader
    {
        public int Id { get; private set; }
        public string UserId { get; private set; } = string.Empty;
        public string CouponCode { get; private set; } = string.Empty;
        public ICollection<CartItem> CartItems { get;  private set; }


        public CartHeader(){}


        protected void ChangeUserId(string userId) 
        {
          UserId = userId;
        }
        protected void ChangeCouponCode(string couponCode)
        {
            CouponCode = couponCode;
        }
    }


}
