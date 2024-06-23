using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResultProductDto>> GetAllProductAsync()
        {
            string query = "EXEC GETALLPRODUCTS";
            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var values = await connection.QueryAsync<ResultProductDto>(query);
                    return values.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "EXEC GetProductsWithCategory";
            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                    return values.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
