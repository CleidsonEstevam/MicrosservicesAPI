namespace ServiceWeb.CartAPI.Repository.Interface
{
    public interface IProductRepository
    {
        Task<bool> IsProductCodeValid(string productCode);
    }
}
