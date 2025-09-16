using proyectoWebApi.DataLayer.Models;

namespace proyectoWebApi.DataLayer.Dapper
{
    public interface IProductRepository

    {
        Task<IEnumerable<Product>> GetAllAsync(int? code);
        Task<int> CreateAsync(Product user);
        Task<bool> UpdateAsync(Product user);
        Task<bool> DeleteAsync(int code);
    }
}
