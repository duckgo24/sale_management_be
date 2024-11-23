using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Dtos.Account;
using Application.Interface;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<TokenDto> signInAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
        public async Task<createAccountDto> signUpAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}