using ServiceWeb.OrderAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceWeb.OrderAPI.Model
{
    public class OrderDetail : BaseEntity
    {
        public long OrderHeaderId { get; set; }
        public virtual OrderHeader OrderHeader { get; set; }
        public string ProductCode { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public OrderDetail(){ }

        public OrderDetail(long orderHeaderId, OrderHeader orderHeader, string productCode, int count, string productName, decimal price)
        {
            OrderHeaderId = orderHeaderId;
            OrderHeader = orderHeader;
            ProductCode = productCode;
            Count = count;
            ProductName = productName;
            Price = price;
        }

    }
}
