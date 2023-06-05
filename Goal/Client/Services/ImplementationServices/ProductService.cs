using Goal.Client.Services.InterfaceServices;
using Goal.Shared.ServerServiceModels;
using Goal.Shared.Entities;
using System.Net.Http.Json;

namespace Goal.Client.Services.ImplementationServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<ProductServiceModel?> AddProduct(Product NewProduct)
        {
            var product = await httpClient.PostAsJsonAsync("api/Product/Add-Product", NewProduct);
            return await product.Content.ReadFromJsonAsync<ProductServiceModel>();
        }

        public async Task<ProductServiceModel?> GetProduct(int ProductId)
        {
            var result = await httpClient.GetAsync($"api/Product/Get-Product/{ProductId}");
            return await result.Content.ReadFromJsonAsync<ProductServiceModel>();
        }

        public async Task<ProductServiceModel?> GetProducts()
        {
            var result = await httpClient.GetAsync("api/Product");
            return await result.Content.ReadFromJsonAsync<ProductServiceModel>();
        }
        public Task<ProductServiceModel?> DeleteProduct(int ProductId)
        {
            throw new NotImplementedException();
        }
    }
}
