using Microsoft.AspNetCore.Identity;
using ServiceWeb.ProductAPI.Model.Base;
using ServiceWeb.ProductAPI.Model.Entities.Execeptions;
using ServiceWeb.ProductAPI.Model.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceWeb.ProductAPI.Model.Entities
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("code")]
        public string Code { get; private set; }

        [Column("name")]
        [Required]
        [StringLength(80)]
        public string Name { get; private set; }

        [Column("description")]
        [Required]
        [StringLength(250)]
        public string Description { get; private set; }

        [Column("supplier")]
        [Required]
        [StringLength(80)]
        public string Supplier { get; private set; }

        [Column("category")]
        [Required]
        [StringLength(20)]
        public string Category { get; private set; }

        [Column("packging_type")]
        [Required]
        [StringLength(10)]
        public string PackagingType { get; private set; }

        [Column("packging_quantity")]
        [Required]
        public int PackagingQuantity { get; private set; }

        [Column("bar_code")]
        [Required]
        [StringLength(16)]
        public string BarCode { get; private set; }

        [Column("origin")]
        [Required]
        [StringLength(1)]
        public string Origin { get; private set; }

        [Column("price")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; private set; }

        //construtor EF
        protected Product() { }

        public Product(string code, string name, string description, string supplier, string category,
            string packagingType, int packagingQuantity, string barCode, string origin, decimal price)
        {
            Code = code;
            Name = name;
            Description = description;
            Supplier = supplier;
            Category = category;
            PackagingType = packagingType;
            PackagingQuantity = packagingQuantity;
            BarCode = barCode;
            Origin = origin;
            Price = price;
            _errors = new List<string>();
        }

        public void ChangeCode(string code)
        {
            Code = code;
            Validate();
        }
        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }
        public void ChangeDescription(string description)
        {
            Description = description;
            Validate();
        }
        public void ChangeSupplier(string supplier)
        {
            Supplier = supplier;
            Validate();
        }
        public void ChangeCategory(string category)
        {
            Category = category;
            Validate();
        }
        public void ChangePackagingType(string packagingType)
        {
            PackagingType = packagingType;
            Validate();
        }
        public void ChangePackagingQuantity(int packagingQuantity)
        {
            PackagingQuantity = packagingQuantity;
            Validate();
        }
        public void ChangeBarCode(string barCode)
        {
            BarCode = barCode;
            Validate();
        }
        public void ChangeOrigin(string origin)
        {
            Origin = origin;
            Validate();
        }
        public void ChangePrice(decimal price)
        {
            Price = price;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new ProductValidator();
         
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);

                    throw new DomainException("Alguns campos inválidos: ", _errors);
                }
            }
            //Se a entidade tiver ok ele retorna true, se não retorna a Exception
            return true;
        }

    }
}
