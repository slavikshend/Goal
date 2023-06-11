using Goal.Shared.Entities;
using Goal.Shared.ServerServiceModels;

namespace Goal.Server.Repositories.Interfaces
{
    public interface IBrandRepo
    {
        public Task<ServiceModel<Brand>> AddBrand(Brand newBrand);
        public Task<ServiceModel<Brand>> DeleteBrand(int id);
        public Task<ServiceModel<Brand>> UpdateBrand(Brand newBrand);
        public Task<ServiceModel<Brand>> GetBrand(int id);
        public Task<ServiceModel<Brand>> GetBrands();
    }
}
