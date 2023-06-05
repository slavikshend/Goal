using Goal.Shared.Entities;

namespace Goal.Shared.ServerServiceModels
{
    public class BrandServiceModel
    {
        public List<Brand>? BrandList { get; set; } = null;
        public Brand? SingleBrand { get; set; } = null;
        public bool Success { get; set; } = true;
        public string? CssClass { get; set; } = "success";
        public string? Message { get; set; } = null;
    }
}
