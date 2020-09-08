using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLiga.Core.Config.Permission;
using GameLiga.Core.DTOModels;
using GameLiga.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameLiga.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        INews _news;
        public NewsController(INews news)
        {
            _news = news;
        }
        [HttpGet]
        public ActionResult GetLatesNews()
        {
            var result = _news.GetLatesNews();
            if (result.IsOk)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("Create")]
        [PermissionAuthorize(Permissions.News.AddNews)]
        public ActionResult CreateNews([FromBody]NewsDTO news)
        {
            var accountId = User.Claims.ToList()[0].Value;
            var result = _news.AddNews(news, int.Parse(accountId));
            if (result.IsOk)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
