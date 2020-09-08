using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLiga.Core.DTOModels;
using GameLiga.Core.Interfaces;
using GameLiga.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameLiga.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;

        public AccountController(IAccount account)
        {
            _account = account;
        }

        [Route("CreateAccount")]
        [HttpPost]
        public ActionResult CreateAccount([FromBody] CreateAccountDto accountDto)
        {
            var result = _account.CreateAccount(accountDto);
            if (result.IsOk == false)
            {
                return BadRequest("This Usernname Exist.");
            }
            return Ok(result.Result);
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult Login([FromBody] LoginDTO accountDto)
        {
            var result = _account.Login(accountDto);
            if (result.IsOk == false)
            {
                return BadRequest(result.Result);
            }
            return Ok(result.Result);
        }

        [Route("CreateAccountdis")]
        [HttpGet]
        public ActionResult DiscordLogin1()
        {
            return Ok("salam");
        }
    }
}
