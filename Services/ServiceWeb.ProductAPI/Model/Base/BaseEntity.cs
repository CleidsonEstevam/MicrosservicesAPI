using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceWeb.ProductAPI.Model.Base
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        internal List<string> _errors;

        //--Ao acessar os erros o programador só vai poder ler e não manipular os dados ex: _erros.Exemplo--
        public IReadOnlyCollection<string> Erros => _errors;
        public abstract bool Validate();
    }
}
