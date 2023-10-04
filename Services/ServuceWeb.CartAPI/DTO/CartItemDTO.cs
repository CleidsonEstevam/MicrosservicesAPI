using ServiceWeb.CartAPI.Model.Entities;

namespace ServiceWeb.CartAPI.DTO
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int CartHeaderId { get; set; }
        public string? ProductCode { get; set; }
    }
}
