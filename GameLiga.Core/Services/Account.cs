using GameLiga.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using GameLiga.Core.Config.Validation.ValidationClasses;
using GameLiga.Core.DTOModels;
using Microsoft.EntityFrameworkCore.Internal;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using GameLiga.Core.Config;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using GameLiga.Core.Interfaces;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using GameLiga.Core.Config.Permission;
using Microsoft.EntityFrameworkCore;
using GameLiga.Infrastructure.Data.Entities;

namespace GameLiga.Core.Services
{
    public class Account : IAccount
    {

        private GameLigaContext _context;
        private readonly AppSetting _appSettings;
        private readonly IMapper _mapper;

        public Account(IOptions<AppSetting> appSettings, IMapper mapper, GameLigaContext context)
        {
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _context = context;
        }
        public BaseResult<string> CreateAccount(CreateAccountDto accountDto)
        {

            var account = _mapper.Map<Infrastructure.Data.Entities.Account>(accountDto);
            if (_context.Account.Where(x => x.Username == account.Username).SingleOrDefault() != null)
            {
                //username Exist.
                return new BaseResult<string>
                {
                    IsOk = false,
                    Result = null
                };
            }
            byte[] salt = null;
            account.Password = accountDto.Password.HashPassword(ref salt);
            account.Salt = salt;
            account.AccountRole.Add(new AccountRole
            {
                RoleId = 1
            });

            _context.Account.Add(account);
            _context.SaveChanges();

            string token = CreateToken(account);
            return new BaseResult<string>
            {
                IsOk = true,
                Result = token
            };
        }

        public BaseResult<string> Login(LoginDTO loginDTO)
        {
            var account = _context.Account.Where(x => x.Username == loginDTO.Username)
                .Include(x => x.AccountPermission)
                    .ThenInclude(x => x.Permission)
                .Include(x => x.AccountRole)
                    .ThenInclude(x => x.Role)
                        .ThenInclude(x => x.RolePermission)
                            .ThenInclude(x => x.Permission)
                .SingleOrDefault();
            if (account == null)
            {
                //mean username is wrong or account dosent exist.
                return new BaseResult<string>
                {
                    IsOk = false,
                    Result = "Username is wrong"
                };
            }
            var salt = account.Salt;
            var password = loginDTO.Password.HashPassword(ref salt);
            if (account.Password != password)
            {
                return new BaseResult<string>
                {
                    IsOk = false,
                    Result = "password Is Wrong"
                };
            }
            string token = CreateToken(account);
            return new BaseResult<string>
            {
                IsOk = true,
                Result = token
            };
        }

        private string CreateToken(Infrastructure.Data.Entities.Account account)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim("Id", account.Id.ToString()));
            claims.AddClaim(new Claim("Username", account.Username));
            claims.AddClaim(new Claim("NickName", account.NickName));
            foreach (var permission in account.AccountPermission)
            {
                claims.AddClaims(new[]
                {
                    new Claim(Permissions.Permission, permission.Permission.Name)
                });
            }
            foreach (var role in account.AccountRole.ToList())
            {
                var RolePermission = _context.RolePermission.Where(x => x.RoleId == role.RoleId).Include(x => x.Permission).ToList();
                foreach (var permission in RolePermission)
                {
                    if (!account.AccountPermission.Any(x => x.Permission.Id == permission.PermissionId))
                    {
                        claims.AddClaims(new[]
                        {
                        new Claim(Permissions.Permission, permission.Permission.Name)
                    });
                    }
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        public string CreateAccountDiscord()
        {
            return "A";
        }

    }
}
