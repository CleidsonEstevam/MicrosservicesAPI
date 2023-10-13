using System.Text.Json.Serialization;

namespace ServiceWeb.CartAPI.DTO
{
    public class CartHeaderDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
