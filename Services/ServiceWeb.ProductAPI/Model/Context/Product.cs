using ServiceWeb.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceWeb.ProductAPI.Model.Context
{
    [Table("product")]
    public class Product 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Code")]
        public string Code { get; set; }

        [Column("name")]
        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Column("description")]
        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Column("supplier")]
        [Required]
        [StringLength(80)]
        public string Supplier { get; set; }

        [Column("category")]
        [Required]
        [StringLength(20)]
        public string Category { get; set; }

        [Column("packging_type")]
        [Required]
        [StringLength(10)]
        public string PackagingType { get; set; }

        [Column("packging_type")]
        [Required]
        public int PackagingQuantity { get; set; }

        [Column("bar_code")]
        [Required]
        [StringLength(16)]
        public string BarCode { get; set; }

        [Column("origin")]
        [Required]
        [StringLength(1)]
        public string Origin { get; set; }

        [Column("price")]
        [Required]
        [Range(1,10000)]
        public decimal Price { get; set; }
    }
}
