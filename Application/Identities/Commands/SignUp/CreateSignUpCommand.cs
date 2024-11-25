using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Account;
using MediatR;

namespace Application.Identities.Commands.SignUp
{
    public class CreateSignUpCommand : IRequest<AccountDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}