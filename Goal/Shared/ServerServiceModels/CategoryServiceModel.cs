using Goal.Shared.Entities;

namespace Goal.Shared.ServerServiceModels
{
    public class CategoryServiceModel
    {
        public List<Category>? CategoryList { get; set; } = null;
        public Category? SingleCategory { get; set; } = null;
        public bool Success { get; set; } = true;
        public string? CssClass { get; set; } = "success";
        public string? Message { get; set; } = null;
    }
}
