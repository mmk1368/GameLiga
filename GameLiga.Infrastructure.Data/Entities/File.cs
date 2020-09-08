using System;
using System.Collections.Generic;

namespace GameLiga.Infrastructure.Data.Entities
{
    public partial class File
    {
        public File()
        {
            News = new HashSet<News>();
        }

        public long Id { get; set; }
        public string FileName { get; set; }
        public string FileExtention { get; set; }
        public byte[] FileContent { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
