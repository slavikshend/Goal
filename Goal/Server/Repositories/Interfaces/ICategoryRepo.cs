using Goal.Shared.Entities;
using Goal.Shared.ServerServiceModels;

namespace Goal.Server.Repositories.Interfaces
{
    public interface ICategoryRepo
    {
        public Task<CategoryServiceModel> AddCategory(Category NewCategory);
        public Task<CategoryServiceModel> GetCategories();
        public Task<CategoryServiceModel> GetCategory(int CategoryId);
        public Task<CategoryServiceModel> DeleteCategory(int CategoryId);
    }
}
