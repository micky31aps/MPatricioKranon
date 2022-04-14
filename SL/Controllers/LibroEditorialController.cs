using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class LibroEditorialController : ApiController
    {
        [HttpGet]
        [Route("api/LibroEditorial/GetByEditorial/{IdEditorial}")]

        public IHttpActionResult GetByEditorial(int IdEditorial)
        {
            ML.Result result = BL.LibroEditorial.LibroGetEditorial(IdEditorial);
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
        [Route("api/LibroEditorial/Delete/{IdEditorial}")]

        public IHttpActionResult Delete(int IdEditorial)
        {
            ML.Editorial editorial = new ML.Editorial();
            editorial.IdEditorial = IdEditorial;
            ML.Result result = BL.LibroEditorial.EditorialDelete(IdEditorial);
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
