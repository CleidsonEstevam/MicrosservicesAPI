

namespace ServiceWeb.ProductAPI.DTO
{
    public class ProductDTO
    {
        public string Code { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string Supplier { get;  set; }
        public string Category { get;  set; }
        public string PackagingType { get;  set; }
        public int PackagingQuantity { get;  set; }
        public string BarCode { get;  set; }
        public string Origin { get;  set; }
        public decimal Price { get;  set; }
    }
}
