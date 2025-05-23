﻿using Goal.Client.Services.InterfaceServices;
using Goal.Shared.Entities;
using Goal.Shared.ServerServiceModels;
using System.Net.Http.Json;

namespace Goal.Client.Services.ImplementationServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient httpClient;
        public CategoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ServiceModel<Category>> AddCategory(Category newCategory)
        {
            var response = await httpClient.PostAsJsonAsync("api/Category", newCategory);
            var result = await response.Content.ReadFromJsonAsync<ServiceModel<Category>>();
            return result!;
        }

        public async Task<ServiceModel<Category>> DeleteCategory(int id)
        {
            var response = await httpClient.DeleteFromJsonAsync<ServiceModel<Category>>($"api/Category/{id}");
            return response!;
        }

        public async Task<ServiceModel<Category>> GetCategories()
        {
            var response = await httpClient.GetAsync("api/Category");
            var result = await response.Content.ReadFromJsonAsync<ServiceModel<Category>>();
            return result!;
        }

        public async Task<ServiceModel<Category>> GetCategory(int id)
        {
            var response = await httpClient.GetAsync($"api/Category/{id}");
            var result = await response.Content.ReadFromJsonAsync<ServiceModel<Category>>();
            return result!;
        }

        public async Task<ServiceModel<Category>> UpdateCategory(Category newCategory)
        {
            var response = await httpClient.PutAsJsonAsync("api/Category", newCategory);
            var result = await response.Content.ReadFromJsonAsync<ServiceModel<Category>>();
            return result!;
        }
    }
}