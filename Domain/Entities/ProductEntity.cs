using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class ProductEntity : BaseEntity
    {

        public string product_desc { get; set; }
        public string category_id { get; set; }

        public virtual CategoryEntity Category { get; set; }
        public virtual AccountEntity Account { get; set; }
        public virtual ICollection<ProductDetailEntity> ListProductDetail { get; set; }
    }
}