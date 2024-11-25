using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Account;
using Application.Interface;
using BCrypt.Net;
using Dapper;
using Domain.Entities;
using Domain.enums;
using Domain.Exceptions;
using MediatR;
using WebApi.DBHelper;

namespace Application.Identities.Commands.SignUp
{
    public class CreateSignUpCommandHandler : IRequestHandler<CreateSignUpCommand, AccountDto>
    {
        private readonly IDbHelper _DbHelper;
        public CreateSignUpCommandHandler(IDbHelper DbHelper, IUser user)
        {
            _DbHelper = DbHelper;
        }

        public async Task<AccountDto> Handle(CreateSignUpCommand request, CancellationToken cancellationToken)
        {

            var checkExitAccount = await _DbHelper.ExcuteProceduceAsync<AccountEntity>
            (
                "sp_find_account_by_username",
                new DynamicParameters(new
                {
                    username = request.Username
                })
            );
            if (checkExitAccount?.acc_id != null)
            {
                throw new BadRequestException("Username is already exist");
            }


            var accountNew = await _DbHelper.ExcuteProceduceAsync<AccountDto>
            (
                "sp_create_account",
                new DynamicParameters(new
                {
                    acc_id = Guid.NewGuid().ToString(),
                    username = request.Username,
                    password = BCrypt.Net.BCrypt.HashPassword(request.Password, 10),
                    role = Role.User.ToString(),
                    is_banned = false,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                })
            );

            return accountNew;
        }
    }
}