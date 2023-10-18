using ServiceWeb.CartAPI.DTO;
using System.ComponentModel.DataAnnotations;

namespace ServiceWeb.CartAPI.ViewModels
{
    public class CheckoutHeaderViewModel
    {
        [Required(ErrorMessage = "O userId não pode ser nulo.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Digite um valor valido.")]
        public decimal PurchaseAmount { get; set; }

        [Required(ErrorMessage = "O Nome não pode ser nulo.")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "O Nome deve ter no máximo 50 caracteres.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O sobrenome não pode ser nulo.")]
        [MinLength(3, ErrorMessage = "O sobrenome deve ter no mínimo 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "O sobrenome deve ter no máximo 50 caracteres.")]
        public string LastName { get; set; }

        public DateTime DateOrder { get; set; }

        [Required(ErrorMessage = "O numero do cartão não pode ser nulo.")]
        [MinLength(3, ErrorMessage = "O numero do cartão deve ter no mínimo 14 caracteres.")]
        [MaxLength(50, ErrorMessage = "O numero do cartão deve ter no máximo 16 caracteres.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "O CVV do cartão não pode ser nulo.")]
        public string CVV { get; set; }

        [Required(ErrorMessage = "a data de validade do cartão não pode ser nulo.")]

        public string ExpiryMothYear { get; set; }

        public int CartTotalItens { get; set; }

        public IEnumerable<CartItemViewModel> CartItems { get; set; }
    }
}
