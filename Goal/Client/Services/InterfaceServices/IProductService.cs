using Goal.Shared.ServerServiceModels;
using Goal.Shared.Entities;

namespace Goal.Client.Services.InterfaceServices
{
    public interface IProductService
    {
        public Task<ProductServiceModel?> AddProduct(Product NewProduct);
        public Task<ProductServiceModel?> GetProducts();
        public Task<ProductServiceModel?> GetProduct(int ProductId);
        public Task<ProductServiceModel?> DeleteProduct(int ProductId);
    }
}
