using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using MediatR;

namespace Application.Identities.Commands.SignIn
{

    public class CreateSignInCommand : IRequest<TokenDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public CreateSignInCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

    }

}