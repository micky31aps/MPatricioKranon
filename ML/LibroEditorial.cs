using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class LibroEditorial
    {
        public int IdLibroEditorial { get; set; }
        public int IdLibro { get; set; }
        public int IdEditorial { get; set; }
        public List<object> LibroEditoriales { get; set; }
        public ML.Editorial Editorial { get; set; }
        public ML.Libro Libro { get; set; }
    }
}
