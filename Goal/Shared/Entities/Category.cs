using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Goal.Shared.Entities
{
    public class Category
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? IconCSS { get; set; }
        [JsonIgnore]
        public List<Product>? Products { get; set; }
    }
}
