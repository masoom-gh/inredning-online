using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InredningOnline.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        public string Description { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
    }
}
