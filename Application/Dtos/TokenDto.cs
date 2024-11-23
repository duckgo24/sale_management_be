using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class TokenDto
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }
}