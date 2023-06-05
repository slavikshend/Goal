using Goal.Server.Repositories.Interfaces;
using Goal.Shared.ServerServiceModels;
using Goal.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Goal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo categoryRepo;
        public CategoryController(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<ActionResult<CategoryServiceModel>> GetCategories()
        {
            return Ok(await categoryRepo.GetCategories());
        }

        [HttpPost("Add-Category")]
        public async Task<ActionResult<CategoryServiceModel>> AddCategory([FromBody] Category NewCategory)
        {
            return Ok(await categoryRepo.AddCategory(NewCategory));
        }

        [HttpGet("Get-Category/{CategoryId:int}")]
        public async Task<ActionResult<CategoryServiceModel>> GetCategory(int CategoryId)
        {
            return Ok(await categoryRepo.GetCategory(CategoryId));
        }
    }
}
