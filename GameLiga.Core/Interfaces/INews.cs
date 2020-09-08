using GameLiga.Core.DTOModels;
using System.Collections.Generic;

namespace GameLiga.Core.Interfaces
{
    public interface INews
    {
        BaseResult<string> AddNews(NewsDTO news, int authorId);
        BaseResult<List<NewsDTO>> GetLatesNews();
    }
}