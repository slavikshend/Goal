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

        public async Task<ServiceModel<Brand>> AddBrand(Brand newBrand)
        {
            var response = await httpClient.PostAsJsonAsync("api/Brand", newBrand);
            var result = await response.Content.ReadFromJsonAsync<ServiceModel<Brand>>();
            return result!;
        }

        public async Task<ServiceModel<Brand>> DeleteBrand(int id)
        {
            var response = await httpClient.DeleteFromJsonAsync<ServiceModel<Brand>>($"api/Brand/{id}");
            return response!;
        }

        public async Task<ServiceModel<Brand>> GetBrands()
        {
            var response = await httpClient.GetAsync("api/Brand");
            var result = await response.Content.ReadFromJsonAsync<ServiceModel<Brand>>();
            return result!;
        }

        public async Task<ServiceModel<Brand>> GetBrand(int id)
        {
            var response = await httpClient.GetAsync($"api/Brand/{id}");
            var result = await response.Content.ReadFromJsonAsync<ServiceModel<Brand>>();
            return result!;
        }

        public async Task<ServiceModel<Brand>> UpdateBrand(Brand newBrand)
        {
            var response = await httpClient.PutAsJsonAsync("api/Brand", newBrand);
            var result = await response.Content.ReadFromJsonAsync<ServiceModel<Brand>>();
            return result!;
        }
    }
}
