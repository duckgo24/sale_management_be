using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string category_name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public virtual AccountEntity Account { get; set; }
        public virtual ICollection<ProductEntity> ListProduct { get; set; }
    }
}