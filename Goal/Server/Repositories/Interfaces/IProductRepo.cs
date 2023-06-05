using Goal.Shared.Entities;
using Goal.Shared.ServerServiceModels;
using Goal.Shared.Dto;
namespace Goal.Server.Repositories.Interfaces
{
    public interface IProductRepo
    {
        public Task<ProductServiceModel> AddProduct(AddProductDto request);
        public Task<ProductServiceModel> GetProducts();
        public Task<ProductServiceModel> GetProduct(int ProductId);
        public Task<ProductServiceModel> DeleteProduct(int ProductId);
    }
}
