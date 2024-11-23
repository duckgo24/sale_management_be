using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductDetailEntity 
    { 
        [Key]
        public string product_detail_id { get; set; } = Guid.NewGuid().ToString();
        public string product_name { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public double price_sale { get; set; }
        public double price_import { get; set; }

        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;

        public string product_id { get; set; }
        public virtual ProductEntity Product { get; set; }

    }
}