using Goal.Shared.Entities;
namespace Goal.Shared.ServerServiceModels
{
    public class ServiceModel<T>
    {
        public List<T>? List { get; set; } = null;
        public T? Single { get; set; } = default;
        public bool Success { get; set; } = true;
        public string? CssClass { get; set; } = "success";
        public string? Message { get; set; } = null;
    }
}
