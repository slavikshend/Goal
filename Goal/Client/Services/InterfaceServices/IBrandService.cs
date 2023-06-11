using Goal.Shared.Entities;
using Goal.Shared.ServerServiceModels;

namespace Goal.Client.Services.InterfaceServices
{
    public interface IBrandService
    {
        Task<ServiceModel<Brand>> AddBrand(Brand newBrand);
        Task<ServiceModel<Brand>> DeleteBrand(int id);
        Task<ServiceModel<Brand>> UpdateBrand(Brand newBrand);
        Task<ServiceModel<Brand>> GetBrand(int id);
        Task<ServiceModel<Brand>> GetBrands();
    }
}
