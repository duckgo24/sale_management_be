using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos.Account
{
    public class AccountDto
    {
        public string acc_id { get; set; }

        public string username { get; set; }
        public string password { get; set; }
        public string role  { get; set; }
        public bool is_banned { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}