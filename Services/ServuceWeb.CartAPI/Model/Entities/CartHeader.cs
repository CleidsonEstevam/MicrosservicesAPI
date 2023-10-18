using ServiceWeb.CartAPI.Model.Entities.Base;
using System.Collections.Specialized;

namespace ServiceWeb.CartAPI.Model.Entities
{
    public class CartHeader : BaseEntity
    {
        //TODO: adicionar validates e privar o set

        public string UserId { get;  set; }
        public CartHeader(){}

        public CartHeader(string userId)
        {
            UserId = userId;
        }

        public void ChangeUserId(string userId)
        {
            UserId = userId;
        }
    }



}
