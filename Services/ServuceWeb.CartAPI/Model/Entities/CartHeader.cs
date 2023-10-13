using System.Collections.Specialized;

namespace ServiceWeb.CartAPI.Model.Entities
{
    public class CartHeader
    {
        public int Id { get; set; }
        public string UserId { get;  set; }
        public string CouponCode { get;  set; }
        public CartHeader(){}
    }


}
