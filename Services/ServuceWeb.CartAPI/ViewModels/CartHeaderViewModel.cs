using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ServiceWeb.CartAPI.ViewModels
{
    public class CartHeaderViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "O UserId não pode ser nulo.")]
        public string UserId { get; set; }
    }
}
