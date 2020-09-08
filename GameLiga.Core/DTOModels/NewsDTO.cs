using System;
using System.Collections.Generic;
using System.Text;

namespace GameLiga.Core.DTOModels
{
    public class NewsDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public FileDTO Pic { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual AccountDTO Author { get; set; }
    }
}
