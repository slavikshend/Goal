using Goal.Shared.Entities;

namespace Goal.Shared.ServerServiceModels
{
    public class ProductServiceModel
    {
        public List<Product>? ProductList { get; set; } = null;
        public Product? SingleProduct { get; set; } = null;
        public bool Success { get; set; } = true;
        public string? CssClass { get; set; } = "success";
        public string? Message { get; set; } = null;
    }
}
