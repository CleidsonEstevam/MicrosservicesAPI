using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceWeb.CartAPI.Model.Entities
{
    public class Product
    {
        public string? ProductCode { get; private set; }

        public string? Name { get; private set; }

        public string? Description { get; private set; }

        public string? Supplier { get; private set; }

        public string? Category { get; private set; }

        public string? PackagingType { get; private set; }

        public int PackagingQuantity { get; private set; }

        public string? BarCode { get; private set; }

        public string? Origin { get; private set; }

        public decimal Price { get; private set; }


        public Product()
        {
                
        }
    }
}
