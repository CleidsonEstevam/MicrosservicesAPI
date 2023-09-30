using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceWeb.CartAPI.Model.Entities
{
    public class Product
    {
        public string? ProductCode { get; private set; }
        public Product() {}
    }
}
