using AutoMapper;
using GameLiga.Core.DTOModels;
using GameLiga.Core.Interfaces;
using GameLiga.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLiga.Core.Services
{
    public class News : INews
    {
        private GameLigaContext _context;
        private readonly IMapper _mapper;

        public News(GameLigaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public BaseResult<List<NewsDTO>> GetLatesNews()
        {
            var news = _context.News.OrderByDescending(x => x.Id).Take(3).Include(x => x.Author).ToList();
            var newsDto = _mapper.Map<List<NewsDTO>>(news);
            return new BaseResult<List<NewsDTO>>
            {
                IsOk = true,
                Result = newsDto
            };
        }

        public BaseResult<string> AddNews(NewsDTO news, int authorId)
        {
            var newsItem = _mapper.Map<GameLiga.Infrastructure.Data.Entities.News>(news);
            string picUrl = string.Empty;
            newsItem.AuthorId = authorId;
            _ = _context.News.Add(newsItem);
            _context.SaveChanges();
            return new BaseResult<string>
            {
                IsOk = true,
                Result = "OK"
            };
        }
    }
}
