using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AccountEntity
    {
        [Key]
        public string acc_id { get; set; } = Guid.NewGuid().ToString();

        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public bool is_banned { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual ICollection<ProductEntity> ListProduct { get; set; }
        public virtual ICollection<CategoryEntity> ListCategory {get; set; }
    }
}