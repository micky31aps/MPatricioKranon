using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class AutorLibroController : ApiController
    {
        [HttpGet]
        [Route("api/AutorLibro/GetByAutor/{IdAutor}")]

        public IHttpActionResult GetByAutor(int IdAutor)
        {
            ML.Result result = BL.AutorLibro.GetAutor(IdAutor);
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
        [Route("api/AutorLibro/AutorGetFecha/{IdAutor}/{AñoPublicacion}")]
        public IHttpActionResult AutorGetFecha(int IdAutor, short AñoPublicacion)
        {
            ML.Result result = BL.AutorLibro.AutorGetFecha(IdAutor, AñoPublicacion);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpDelete]
        [Route("api/AutorLibro/Delete/{IdAutor}")]

        public IHttpActionResult Delete(int IdAutor)
        {
            ML.Autor autor = new ML.Autor();
            autor.IdAutor = IdAutor;
            ML.Result result = BL.AutorLibro.AutorDelete(IdAutor);
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
