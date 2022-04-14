using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class AutorLibro
    {
        public int IdAutorLibro { get; set; }
        public ML.Autor Autor { get; set; }
        public ML.Libro Libro { get; set; }
        public List<object> AutorLibros { get; set; }

    }
}
