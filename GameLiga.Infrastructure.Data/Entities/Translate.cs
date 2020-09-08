using System;
using System.Collections.Generic;

namespace GameLiga.Infrastructure.Data.Entities
{
    public partial class Translate
    {
        public int Id { get; set; }
        public int TextId { get; set; }
        public string TranslatedText { get; set; }
        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }
        public virtual Text Text { get; set; }
    }
}
