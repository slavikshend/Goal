using Goal.Shared.Entities;
using Goal.Shared.ServerServiceModels;

namespace Goal.Client.Services.InterfaceServices
{
    public interface IBrandService
    {
        public Task<BrandServiceModel?> AddBrand(Brand NewBrand);
        public Task<BrandServiceModel?> GetBrands();
        public Task<BrandServiceModel?> GetBrand(int BrandId);
        public Task<BrandServiceModel?> DeleteBrand(int BrandId);
    }
}
