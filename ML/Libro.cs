using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string TituloLibro { get; set; }
        public short AñoPublicacion { get; set; }
        public byte[]  Imagen { get; set; }
        public List<object> Libros { get; set; }
    }
}
