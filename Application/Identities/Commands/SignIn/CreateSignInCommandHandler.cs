using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Dtos.Account;
using BCrypt.Net;
using Dapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using WebApi.DBHelper;


namespace Application.Identities.Commands.SignIn
{
    public class CreateSignInCommandHandler : IRequestHandler<CreateSignInCommand, TokenDto>
    {
        private readonly IDbHelper _DbHelper;
        private readonly IJwtService _jwtService;
        public CreateSignInCommandHandler(IDbHelper DbHelper, IJwtService jwtService)
        {
            _DbHelper = DbHelper;
            _jwtService = jwtService;
        }

        public async Task<TokenDto> Handle(CreateSignInCommand request, CancellationToken cancellationToken)
        {
            var account = await _DbHelper.ExcuteProceduceSingleDataAsync<AccountEntity>
            (
                "sp_find_account_by_username",
                new DynamicParameters(new
                {
                    username = request.Username
                })
            );
            if (account?.acc_id == null)
            {
                throw new NotFoundException("Username is not exist.");
            }

            var isMathPassword = BCrypt.Net.BCrypt.Verify(request.Password, account.password);
            if (!isMathPassword)
            {
                throw new BadRequestException("Password is incorrect.");
            }
        
            return new TokenDto
            {
                accessToken = _jwtService.generateAccessToken(account),
                refreshToken = _jwtService.generateRefreshToken(account)
            };
        }
    }
}