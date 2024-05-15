using Application.DTOs;

namespace Application.Abstractions.Interfaces
{
    public interface ICategoryRepo
    {
        GetCategoryDTOs Get(int pageNo, int pageSize);
        Task<int> Add(AddCategoryDTO dto);
        Task<int> Update(int id, UpdateCategoryDTO dto);
        Task<int> Delete(int id);
    }
}
