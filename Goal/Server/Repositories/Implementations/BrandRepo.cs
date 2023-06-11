using Goal.Server.Context;
using Goal.Server.Repositories.Interfaces;
using Goal.Shared.ServerServiceModels;
using Goal.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Goal.Server.Repositories.Implementations
{
    public class BrandRepo : IBrandRepo
    {
        private readonly ShopOnlineDbContext appDbContext;
        public BrandRepo(ShopOnlineDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceModel<Brand>> AddBrand(Brand NewBrand)
        {
            var Response = new ServiceModel<Brand>();
            if (NewBrand != null)
            {
                try
                {
                    appDbContext.Brands.Add(NewBrand);
                    await appDbContext.SaveChangesAsync();
                    Response.Single = NewBrand;
                    Response.Success = true;
                    Response.Message = "Brand added successfully!";
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
                Response.Message = "Brand object is null";
                Response.CssClass = "warning";
                Response.Single = null!;
                return Response;
            }
        }
        public async Task<ServiceModel<Brand>> GetBrands()
        {
            var Response = new ServiceModel<Brand>();
            try
            {
                var brands = await appDbContext.Brands.ToListAsync();
                if (brands != null)
                {
                    Response.List = brands;
                    Response.Success = true;
                    Response.Message = "Brands found!";
                    Response.CssClass = "success";
                    return Response;
                }
                else
                {
                    Response.Success = false;
                    Response.Message = "No brands found!";
                    Response.CssClass = "info";
                    Response.List = null!;
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
        public async Task<ServiceModel<Brand>> GetBrand(int brandId)
        {
            var response = new ServiceModel<Brand>();

            try
            {
                var brand = await appDbContext.Brands.FirstOrDefaultAsync(p => p.Id == brandId);

                if (brand != null)
                {
                    response.Single = brand;
                    response.Success = true;
                    response.Message = "Brand found!";
                    response.CssClass = "success";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Brand not found!";
                    response.CssClass = "warning";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.CssClass = "danger";
            }

            return response;
        }
        public async Task<ServiceModel<Brand>> DeleteBrand(int id)
        {
            var response = new ServiceModel<Brand>();
            if (id > 0)
            {
                var brand = await GetBrand(id);
                if (brand != null)
                {
                    appDbContext.Brands.Remove(brand!.Single!);
                    await appDbContext.SaveChangesAsync();
                    response.Message = $"Brand with the name {brand.Single?.Name} deleted!";
                    response.Success = false;
                    response.CssClass = "danger fw-bold";
                    response.Single = brand.Single;
                    var list = await GetBrands();
                    response.List = list.List;
                }
                else
                {
                    response.Message = brand!.Message;
                    response.Success = brand.Success;
                    response.CssClass = brand.CssClass;
                }
            }
            else
            {
                response.Message = "Invalid brand!";
                response.Success = false;
                response.CssClass = "danger fw-bold";
            }
            return response;
        }
        public async Task<ServiceModel<Brand>> UpdateBrand(Brand newBrand)
        {
            var response = new ServiceModel<Brand>();
            if (newBrand != null)
            {
                var brand = await GetBrand(newBrand.Id);
                if (brand.Single != null)
                {
                    brand.Single.Name = newBrand.Name;
                    await appDbContext.SaveChangesAsync();
                    response.Message = "Brand updated!";
                    response.CssClass = "success fw-bold";
                    response.Single = brand.Single;
                    response.Success = true;
                    var categories = await GetBrands();
                    response.List = categories.List;
                }
                else
                {
                    response.Message = brand.Message;
                    response.CssClass = brand.CssClass;
                    response.Success = brand.Success;
                }
            }
            else
            {
                response.Message = "Brand object is empty!";
                response.CssClass = "danger fw-bold";
                response.Success = false;
            }
            return response;
        }
    }
}
