using Goal.Client.Services.InterfaceServices;
using Goal.Shared.ServerServiceModels;
using Goal.Shared.Entities;
using System.Net.Http.Json;
namespace Goal.Client.Services.ImplementationServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient httpClient;
        public BrandService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<BrandServiceModel?> AddBrand(Brand NewBrand)
        {
            var brand = await httpClient.PostAsJsonAsync("api/Brand/Add-Brand", NewBrand);
            return await brand.Content.ReadFromJsonAsync<BrandServiceModel>();
        }

        public async Task<BrandServiceModel?> GetBrand(int BrandId)
        {
            var result = await httpClient.GetAsync($"api/Brand/Get-Brand/{BrandId}");
            return await result.Content.ReadFromJsonAsync<BrandServiceModel>();
        }

        public async Task<BrandServiceModel?> GetBrands()
        {
            var result = await httpClient.GetAsync("api/Get-Brands");
            return await result.Content.ReadFromJsonAsync<BrandServiceModel>();
        }
        public Task<BrandServiceModel?> DeleteBrand(int BrandId)
        {
            throw new NotImplementedException();
        }
    }
}
