using System;
using System.Collections.Generic;

namespace GameLiga.Infrastructure.Data.Entities
{
    public partial class Language
    {
        public Language()
        {
            Translate = new HashSet<Translate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<Translate> Translate { get; set; }
    }
}
