using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LibroEditorialController : Controller
    {
        [HttpGet]
        public ActionResult AutorGetLibro()
        {
            ML.Result result = new ML.Result();
            ML.AutorLibro autor = new ML.AutorLibro();
            if (result.Correct)
            {
                autor.AutorLibros = result.Objects.ToList();
            }
            return View(autor);
        }
	}
}