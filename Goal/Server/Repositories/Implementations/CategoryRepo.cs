using Goal.Server.Repositories.Interfaces;
using Goal.Server.Context;
using Goal.Shared.ServerServiceModels;
using Goal.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Goal.Server.Repositories.Implementations
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ShopOnlineDbContext appDbContext;
        public CategoryRepo(ShopOnlineDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<CategoryServiceModel> AddCategory(Category NewCategory)
        {
            var Response = new CategoryServiceModel();
            if (NewCategory != null)
            {
                try
                {
                    appDbContext.Categories.Add(NewCategory);
                    await appDbContext.SaveChangesAsync();
                    Response.SingleCategory = NewCategory;
                    Response.Success = true;
                    Response.Message = "Category added successfully!";
                    Response.CssClass = "success";
                    return Response;
                }
                catch (Exception exMessage)
                {
                    Response.CssClass = "danger";
                    Response.Message = exMessage.Message.ToString();
                    return Response;
                }
            }
            else
            {
                Response.Success = false;
                Response.Message = "Category object is null";
                Response.CssClass = "warning";
                Response.SingleCategory = null!;
                return Response;
            }
        }
        public async Task<CategoryServiceModel> GetCategories()
        {
            var Response = new CategoryServiceModel();
            try
            {
                var categories = await appDbContext.Categories.ToListAsync();
                if (categories != null)
                {
                    Response.CategoryList = categories;
                    Response.Success = true;
                    Response.Message = "Categories found!";
                    Response.CssClass = "success";
                    return Response;
                }
                else
                {
                    Response.Success = false;
                    Response.Message = "No categories found!";
                    Response.CssClass = "info";
                    Response.CategoryList = null!;
                    return Response;
                }

            }
            catch (Exception exMessage)
            {
                Response.CssClass = "danger";
                Response.Message = exMessage.Message.ToString();
                return Response;
            }
        }
        public async Task<CategoryServiceModel> GetCategory(int CategoryId)
        {
            var Response = new CategoryServiceModel();
            if (CategoryId > 0)
            {
                try
                {
                    var category = await appDbContext.Categories.SingleOrDefaultAsync(p => p.Id == CategoryId);
                    if (category != null)
                    {
                        Response.SingleCategory = category;
                        Response.Success = true;
                        Response.Message = "Category found!";
                        Response.CssClass = "success";
                        return Response;
                    }
                    else
                    {
                        Response.Success = false;
                        Response.Message = "Category doesn't exist!";
                        Response.CssClass = "info";
                        Response.SingleCategory = null!;
                        return Response;
                    }

                }
                catch (Exception exMessage)
                {
                    Response.CssClass = "danger";
                    Response.Message = exMessage.Message.ToString();
                    return Response;
                }
            }
            else
            {
                Response.Success = false;
                Response.Message = "Category object is empty!";
                Response.CssClass = "warning";
                Response.SingleCategory = null!;
                return Response;
            }
        }
        public Task<CategoryServiceModel> DeleteCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }
    }
}
