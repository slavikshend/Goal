using Goal.Server.Repositories.Interfaces;
using Goal.Shared.ServerServiceModels;
using Goal.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Goal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepo brandRepo;
        public BrandController(IBrandRepo brandRepo)
        {
            this.brandRepo = brandRepo;
        }

        [HttpGet("Get-Brands")]
        public async Task<ActionResult<BrandServiceModel>> GetBrands()
        {
            return Ok(await brandRepo.GetBrands());
        }

        [HttpPost("Add-Brand")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BrandServiceModel>> AddBrand([FromBody]Brand NewBrand)
        {
            return Ok(await brandRepo.AddBrand(NewBrand));
        }

        [HttpGet("Get-Brand/{BrandId:int}")]
        public async Task<ActionResult<BrandServiceModel>> GetBrand(int BrandId)
        {
            return Ok(await brandRepo.GetBrand(BrandId));
        }
    }
}
