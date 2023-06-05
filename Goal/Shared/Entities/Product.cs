﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Goal.Shared.Entities
{
    public class Product
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Required, StringLength(50, MinimumLength = 6)]
        public string? Name { get; set; }
        [Required, DataType(DataType.Currency)]
        public double OriginalPrice { get; set; } = 0.52;
        [DataType(DataType.Currency)]
        public double NewPrice { get; set; } = 0.00;
        public string? Description { get; set; }
        public Category? Category { get; set; }
        public Brand? Brand { get; set; }
        public int Quantity { get; set; } = 1;
        [Required]
        public string? Image { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime UploadedDate { get; set; } = DateTime.Now;
    }
}
