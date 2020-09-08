using System;
using System.Collections.Generic;

namespace GameLiga.Infrastructure.Data.Entities
{
    public partial class Text
    {
        public Text()
        {
            Translate = new HashSet<Translate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Translate> Translate { get; set; }
    }
}
