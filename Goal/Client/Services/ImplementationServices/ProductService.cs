﻿using Goal.Client.Services.InterfaceServices;
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
        public async Task<ServiceModel<Product>?> AddProduct(Product NewProduct)
        {
            var product = await httpClient.PostAsJsonAsync("api/Product/Add-Product", NewProduct);
            return await product.Content.ReadFromJsonAsync<ServiceModel<Product>>();
        }

        public async Task<ServiceModel<Product>?> DeleteProduct(int id)
        {
            var result = await httpClient.DeleteFromJsonAsync<ServiceModel<Product>>($"api/Product/{id}");
            return result;
        }

        public async Task<ServiceModel<Product>?> GetProduct(int ProductId)
        {
            var result = await httpClient.GetAsync($"api/Product/Get-Product/{ProductId}");
            return await result.Content.ReadFromJsonAsync<ServiceModel<Product>>();
        }

        public async Task<ServiceModel<Product>?> GetProducts()
        {
            var result = await httpClient.GetAsync("api/Product");
            return await result.Content.ReadFromJsonAsync<ServiceModel<Product>>();
        }

        public async Task<ServiceModel<Product>?> UpdateProduct(Product NewProduct)
        {
            var result = await httpClient.PutAsJsonAsync("api/Product", NewProduct);
            return await result.Content.ReadFromJsonAsync<ServiceModel<Product>>();
        }
    }
}
