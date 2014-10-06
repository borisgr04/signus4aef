using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ByAUtil
{
    public class ByARpt
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public int Filas { get; set; }

        public static implicit operator bool(ByARpt bya)
        {
            return bya.Error;
        }

        public static implicit operator string(ByARpt bya)
        {
            return bya.Mensaje;
        }

        public static implicit operator int(ByARpt bya)
        {
            return bya.Filas;
        }
    }
}
