using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class LibroController : ApiController
    {
        [HttpPost]
        [Route("api/Libro/Add")]
        public IHttpActionResult Add([FromBody] ML.Libro libro)
        {
            ML.Result result = BL.Libro.Add(libro);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [HttpGet]
        [Route("api/Libro/GetByTitulo/{TituloLibro}")]

        public IHttpActionResult GetByTitulo(string TituloLibro)
        {
            ML.Libro libro = new ML.Libro();
            libro.TituloLibro = TituloLibro;
            ML.Result result = BL.Libro.GetTitulo(libro);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
