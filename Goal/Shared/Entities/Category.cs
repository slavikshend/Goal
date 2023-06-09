using Goal.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Goal.Shared.Entities
{
	public class Category
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Url { get; set; }
		public string? Image { get; set; }
		public DateTime? DateCreated { get; set; } = DateTime.Now;

		[JsonIgnore]
        public List<Product>? Products { get; set; }
	}
}