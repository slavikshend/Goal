using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Goal.Shared.Entities
{
   public class Brand
   {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50, MinimumLength = 4, ErrorMessage = "Назва має складатися з 4 або більше символів.")]
        public string? Name { get; set; }
        [JsonIgnore]
        public List<Product>? Products { get; set; }
    }
}
