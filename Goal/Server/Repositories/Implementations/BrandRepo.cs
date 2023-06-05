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
        public async Task<BrandServiceModel> AddBrand(Brand NewBrand)
        {
            var Response = new BrandServiceModel();
            if (NewBrand != null)
            {
                try
                {
                    appDbContext.Brands.Add(NewBrand);
                    await appDbContext.SaveChangesAsync();
                    Response.SingleBrand = NewBrand;
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
                Response.SingleBrand = null!;
                return Response;
            }
        }
        public async Task<BrandServiceModel> GetBrands()
        {
            var Response = new BrandServiceModel();
            try
            {
                var brands = await appDbContext.Brands.ToListAsync();
                if (brands != null)
                {
                    Response.BrandList = brands;
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
                    Response.BrandList = null!;
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
        public async Task<BrandServiceModel> GetBrand(int BrandId)
        {
            var Response = new BrandServiceModel();
            if (BrandId > 0)
            {
                try
                {
                    var brand = await appDbContext.Brands.SingleOrDefaultAsync(p => p.Id == BrandId);
                    if (brand != null)
                    {
                        Response.SingleBrand = brand;
                        Response.Success = true;
                        Response.Message = "Brand found!";
                        Response.CssClass = "success";
                        return Response;
                    }
                    else
                    {
                        Response.Success = false;
                        Response.Message = "Brand doesn't exist!";
                        Response.CssClass = "info";
                        Response.SingleBrand = null!;
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
                Response.Message = "Brand object is empty!";
                Response.CssClass = "warning";
                Response.SingleBrand = null!;
                return Response;
            }
        }
        public async Task<BrandServiceModel> DeleteBrand(int BrandId)
        {
            throw new NotImplementedException();
        }
    }
}
