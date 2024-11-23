using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserEntity 
    {
        [Key]
        public string user_id { get; set; }
        public string full_name { get; set; }
        public string nick_name { get; set; }
        public string gender { get; set; }
        public DateTime birth { get; set; }
        public string avatar { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string acc_id { get; set; }

        public virtual AccountEntity Account { get; set; }
    }
}