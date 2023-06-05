using Goal.Shared.ServerServiceModels;
using Goal.Shared.Entities;

namespace Goal.Server.Repositories.Interfaces
{
    public interface IBrandRepo
    {
        public Task<BrandServiceModel> AddBrand(Brand NewBrand);
        public Task<BrandServiceModel> GetBrands();
        public Task<BrandServiceModel> GetBrand(int ProductId);
        public Task<BrandServiceModel> DeleteBrand(int ProductId);
    }
}
