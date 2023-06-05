using Goal.Server.Repositories.Interfaces;
using Goal.Shared.ServerServiceModels;
using Goal.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Goal.Server.Controllers
{
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
