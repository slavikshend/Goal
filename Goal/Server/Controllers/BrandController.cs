using Goal.Server.Repositories.Interfaces;
using Goal.Shared.ServerServiceModels;
using Goal.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult<ServiceModel<Brand>>> GetBrands()
        {
            return Ok(await brandRepo.GetBrands());
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceModel<Brand>>> AddBrand([FromBody]Brand NewBrand)
        {
            return Ok(await brandRepo.AddBrand(NewBrand));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceModel<Brand>>> GetBrand(int id)
        {
            return Ok(await brandRepo.GetBrand(id));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceModel<Brand>>> DeleteBrand(int id)
        {
            return Ok(await brandRepo.DeleteBrand(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceModel<Brand>>> UpdateBrand(Brand newBrand)
        {
            return Ok(await brandRepo.UpdateBrand(newBrand));
        }
    }
}
