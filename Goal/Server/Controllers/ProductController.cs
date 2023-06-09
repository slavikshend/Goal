using Goal.Server.Context;
using Goal.Server.Repositories.Interfaces;
using Goal.Shared.ServerServiceModels;
using Goal.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Goal.Shared.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Goal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo productRepo;
        public ProductController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }
        [HttpPost("Add-Product")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProductServiceModel>> AddProduct(AddProductDto request)
        {
            return Ok(await productRepo.AddProduct(request));
        }

        [HttpGet]
        public async Task<ActionResult<ProductServiceModel>> GetProducts()
        {
            return Ok(await productRepo.GetProducts());
        }

        [HttpGet("Get-Product/{ProductId:int}")]
        public async Task<ActionResult<ProductServiceModel>> GetProduct(int ProductId)
        {
            return Ok(await productRepo.GetProduct(ProductId));
        }
    }
}
