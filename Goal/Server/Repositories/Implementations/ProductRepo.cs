using Goal.Server.Repositories.Interfaces;
using Goal.Server.Context;
using Goal.Shared.ServerServiceModels;
using Goal.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Goal.Shared.Dto;

namespace Goal.Server.Repositories.Implementations
{
    public class ProductRepo : IProductRepo
    {
        private readonly ShopOnlineDbContext appDbContext;
        public ProductRepo(ShopOnlineDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ProductServiceModel> AddProduct(AddProductDto request)
        {
            var Response = new ProductServiceModel();
            var brand = await appDbContext.Brands.FindAsync(request.BrandId);
            var category = await appDbContext.Categories.FindAsync(request.CategoryId);
            if (brand == null || category == null) {
                Response.Success = false;
                Response.Message = "Error";
                Response.CssClass = "danger";
            }
            var NewProduct = new Product
            {
                Name = request.Name,
                OriginalPrice = request.OriginalPrice,
                NewPrice = request.NewPrice,
                Description = request.Description,
                Category = category,
                Brand = brand,
                Quantity = request.Quantity,
                Image = request.Image,
                UploadedDate = request.UploadedDate
            };
            if (NewProduct != null)
            {
                try
                {
                    appDbContext.Products.Add(NewProduct);
                    await appDbContext.SaveChangesAsync();
                    Response.SingleProduct = NewProduct;
                    Response.Success = true;
                    Response.Message = "Product added successfully!";
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
                Response.Message = "Sorry New product object is empty!";
                Response.CssClass = "warning";
                Response.SingleProduct = null!;
                return Response;
            }
        }
        public async Task<ProductServiceModel> GetProduct(int ProductId)
        {
            var Response = new ProductServiceModel();
            if (ProductId > 0)
            {
                try
                {
                    var product = await appDbContext.Products.SingleOrDefaultAsync(p => p.Id == ProductId);
                    if (product != null)
                    {
                        Response.SingleProduct = product;
                        Response.Success = true;
                        Response.Message = "Product found!";
                        Response.CssClass = "success";
                        return Response;
                    }
                    else
                    {
                        Response.Success = false;
                        Response.Message = "Product doesn't exist!";
                        Response.CssClass = "info";
                        Response.SingleProduct = null!;
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
                Response.Message = "Sorry New product object is empty!";
                Response.CssClass = "warning";
                Response.SingleProduct = null!;
                return Response;
            }
        }
        public async Task<ProductServiceModel> GetProducts()
        {
            var Response = new ProductServiceModel();
            try
            {
                var products = await appDbContext.Products.ToListAsync();
                if (products != null)
                {
                    Response.ProductList = products;
                    Response.Success = true;
                    Response.Message = "Products found!";
                    Response.CssClass = "success";
                    return Response;
                }
                else
                {
                    Response.Success = false;
                    Response.Message = "No products found!";
                    Response.CssClass = "info";
                    Response.ProductList = null!;
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
        public Task<ProductServiceModel> DeleteProduct(int ProductId)
        {
            throw new NotImplementedException();
        }
    }
}