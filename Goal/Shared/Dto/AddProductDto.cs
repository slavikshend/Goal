using Goal.Shared.Entities;
using System.Text.Json.Serialization;

namespace Goal.Shared.Dto
{
    public class AddProductDto
    {
        public string? Name { get; set; }
        public double OriginalPrice { get; set; } = 0.52;
        public double NewPrice { get; set; } = 0.00;
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int Quantity { get; set; } = 1;
        public string? Image { get; set; }
        public DateTime UploadedDate { get; set; } = DateTime.Now;
    }
}
