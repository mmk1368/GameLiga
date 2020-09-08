using System;
using System.Collections.Generic;

namespace GameLiga.Infrastructure.Data.Entities
{
    public partial class News
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public long? PicId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Account Author { get; set; }
        public virtual File Pic { get; set; }
    }
}
