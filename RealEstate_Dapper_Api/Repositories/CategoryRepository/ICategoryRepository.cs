using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<ResultCategoryDto>> GetAllCategoryAsync();

        Task CreateCategoryAsycnc(CreateCategoryDto createCategoryDto);

        Task DeleteCategoryAsycnc(int id);

        Task UpdateCategory(UpdateCategoryDto createCategoryDto);


        Task<ResultCategoryDto> GetCategoryByIdAsync(int id);
    }
}
