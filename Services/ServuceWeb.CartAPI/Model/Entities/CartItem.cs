using ServiceWeb.CartAPI.Model.Entities.Base;

namespace ServiceWeb.CartAPI.Model.Entities
{
    public class CartItem : BaseEntity
    {
        //TODO: adicionar validates e privar o set


        public int Quantity { get;  set; }
        public long CartHeaderId { get;  set; }
        public string? ProductCode { get;  set; }
        public CartItem(){}

        public CartItem(int quantity, int cartHeaderId, string? productCode)
        {
            Quantity = quantity;
            CartHeaderId = cartHeaderId;
            ProductCode = productCode;
        }

    }
}
