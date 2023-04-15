using FluentValidation;
using ServiceWeb.ProductAPI.Model.Entities;

namespace ServiceWeb.ProductAPI.Model.Validations
{
    public class ProductValidator :  AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //Validação para a entidade num geral 
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A Entidade não pode ser nula.");

            RuleFor(x => x.Code)
                .NotNull()
                .WithMessage("O código não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O código não pode ser vazio.")

                .MaximumLength(6)
                .WithMessage("O código pode ter no máximo 6 caracteres");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome precisa ter no minimo 3 caracteres")

                .MaximumLength(80)
                .WithMessage("O nome precisa ter no máximo 80 caracteres");
           
            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("A descrição não pode ser nula.")

                .NotEmpty()
                .WithMessage("A descrição não pode ser vazia.")

                .MaximumLength(250)
                .WithMessage("A descrição ter no máximo 250 caracteres");

            RuleFor(x => x.Supplier)
                .NotNull()
                .WithMessage("O fornecedor não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O fornecedor não pode ser vazio.")

                .MaximumLength(20)
                .WithMessage("O fornecedor deve ter no máximo 20 caracteres");

            RuleFor(x => x.Category)
                .NotNull()
                .WithMessage("A categoria não pode ser nulo.")

                .NotEmpty()
                .WithMessage("A categoria não pode ser vazio.")

                .MaximumLength(20)
                .WithMessage("A categoria deve ter no máximo 20 caracteres");

            RuleFor(x => x.PackagingType)
               .NotNull()
               .WithMessage("O tipo do pacote não pode ser nulo.")

               .NotEmpty()
               .WithMessage("O tipo do pacote não pode ser vazio.")

               .MaximumLength(20)
               .WithMessage("O tipo do pacote deve ter no máximo 20 caracteres");

            RuleFor(x => x.PackagingQuantity)
               .NotNull()
               .WithMessage("A quantidade não pode ser nula.")

               .NotEmpty()
               .WithMessage("A quantidade não pode ser vazia.");

            RuleFor(x => x.BarCode)
               .NotNull()
               .WithMessage("O codigo de barras não pode ser nulo.")

               .NotEmpty()
               .WithMessage("O codigo de barras não pode ser vazio.")

               .MaximumLength(16)
               .WithMessage("O codigo de barras deve ter no máximo 16 caracteres");


            RuleFor(x => x.Origin)
               .NotNull()
               .WithMessage("A origem não pode ser nula.")

               .NotEmpty()
               .WithMessage("A origem não pode ser vazia.")

               .MaximumLength(1)
               .WithMessage("A origem deve ter no máximo 1 caracterer");

            RuleFor(x => x.Price)
              .NotNull()
              .WithMessage("O preço não pode ser nulo.")

              .NotEmpty()
              .WithMessage("O preço não pode ser vazio.");
        }
    }
}
