using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Dtos.Account;

namespace Application.Interface
{
    public interface IAccountRepository
    {
       Task<TokenDto> signInAsync(string username, string password);
       Task<createAccountDto> signUpAsync(string username, string password);
    }
}