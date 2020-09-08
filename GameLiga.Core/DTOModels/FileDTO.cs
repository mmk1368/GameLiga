using System;
using System.Collections.Generic;
using System.Text;

namespace GameLiga.Core.DTOModels
{
    public class FileDTO
    {
        public string FileName { get; set; }
        public string FileExtention { get; set; }
        public byte[] FileContent { get; set; }
    }
}
