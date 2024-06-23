using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ResultProductDto>> GetAllProductAsync();

        Task<IEnumerable<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
    }
}
