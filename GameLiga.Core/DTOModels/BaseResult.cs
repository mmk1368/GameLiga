using System;
using System.Collections.Generic;
using System.Text;

namespace GameLiga.Core.DTOModels
{
    public class BaseResult<T>
    {
        public bool IsOk { get; set; }
        public T Result { get; set; }
    }
}
