using ServiceWeb.CartAPI.Model.Entities;
using System.Text.Json.Serialization;

namespace ServiceWeb.CartAPI.DTO
{
    public class CartItemDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public int CartHeaderId { get; set; }
        public string? ProductCode { get; set; }
    }
}
