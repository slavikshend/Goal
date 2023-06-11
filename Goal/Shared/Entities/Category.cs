using Goal.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Goal.Shared.Entities
{
	public class Category
	{
        [Key]
        public int Id { get; set; }
		public string? Name { get; set; }
		public string? Url { get; set; }
		public string? Image { get; set; }
		[JsonIgnore]
        public List<Product>? Products { get; set; }

    }
}