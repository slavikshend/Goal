using System.ComponentModel.DataAnnotations;

namespace Goal.Shared.Entities
{
    public class User
    {
        [Key]
        public string? UserName { get; set; }
        public string? Password { get ; set; }
        public string? Role { get; set; }
    }
}
