using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ServiceWeb.CartAPI.ViewModels
{
    public class CartItemViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite uma quantidade.")]
        public int Quantity { get; set; }
        [JsonIgnore]
        public int CartHeaderId { get; set; }

        [Required(ErrorMessage = "Adicione um produto.")]
        public string? ProductCode { get; set; }
    }
}
