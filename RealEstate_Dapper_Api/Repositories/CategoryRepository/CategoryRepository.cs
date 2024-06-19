using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Data;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsycnc(CreateCategoryDto createCategoryDto)
        {
            string? command = $"EXEC InsertCategory @CategoryName = '{createCategoryDto.CategoryName}', @CategoryStatus = 1;";
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(command);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        public async Task DeleteCategoryAsycnc(int id)
        {
            string? command= $"EXEC RemoveCategory @CategoryID = {id}";
            try
            {
                
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(command);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ResultCategoryDto>> GetAllCategoryAsync()
        {
            //string query = "exec GetCategories";
            string query = "EXEC GetCategories";
            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var values = await connection.QueryAsync<ResultCategoryDto>(query);
                    return values.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ResultCategoryDto> GetCategoryByIdAsync(int id)
        {
            string query = $"EXEC GetCategoryById @CategoryID ={id}";
            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var values = await connection.QueryFirstOrDefaultAsync<ResultCategoryDto>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateCategory(UpdateCategoryDto categoryDto)
        {
            var command = $"EXEC UpdateCategory @CategoryID = {categoryDto.CategoryID}, @CategoryName = '{categoryDto.CategoryName}', @CategoryStatus = {categoryDto.CategoryStatus}";
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(command);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
