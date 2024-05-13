using Application.Abstractions.Interfaces;
using Application.DTOs;
using Persistence;
using Persistence.Entities;

namespace Application.Abstractions.Implementations
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<int> Add(AddCategoryDTO dto)
        {
            Category category = new Category
            {
                Name = dto.Name,
                CreatedOn = DateTime.Now
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<int> Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(_ => _.Id == id);
            if(category != null)
            {
                category.IsDeleted = true;
                await _context.SaveChangesAsync();
                return category.Id;
            }
            else
                throw new Exception("Category does not exist.");
        }

        public List<GetCategoryDTO> Get(int pageNo, int pageSize)
        {
            var categories = _context.Categories.Select(_ => new GetCategoryDTO
            {
                Id = _.Id,
                Name = _.Name,
                CreatedOn = _.CreatedOn
            }).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            return categories;
        }

        public async Task<int> Update(int id, UpdateCategoryDTO dto)
        {
            var category = _context.Categories.FirstOrDefault(_ => _.Id == id);
            if (category != null)
            {
                category.Name = dto.Name;
                category.UpdatedOn = DateTime.Now;
                await _context.SaveChangesAsync();
                return category.Id;
            }
            else
                throw new Exception("Category does not exist.");
        }
    }
}
