using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            ML.Result result = BL.Libro.GetTitulo(libro);

            if (result.Correct)
            {
                libro.Libros = result.Objects;
            }
            else
            {

            }
            return View(libro);
        }
        [HttpPost]
        public ActionResult GetAll(ML.Libro libro)
        {
            //ML.Libro libro = new ML.Libro();
            libro.Libros = new List<object>();
            
                using (var client = new HttpClient())
                {
                    if (libro.TituloLibro == null)
                    {
                        libro.TituloLibro = "1";
                    }
                    string UrlApi = System.Configuration.ConfigurationManager.AppSettings["WebAPI"].ToString();
                    client.BaseAddress = new Uri(UrlApi);
                    var responseTask = client.GetAsync("Libro/GetByTitulo/" + libro.TituloLibro);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Libro libroList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(resultItem.ToString());
                            libro.Libros.Add(libroList);
                        }
                    }
                }  
            
            
            return View(libro);
        }
        public ActionResult Form(int? IdLibro)
        {
            
            ML.Libro libro = new ML.Libro();
            if (IdLibro == null)
            {
                return View(libro);
            }
            else
            {
                ML.Result result = BL.Libro.GetById(IdLibro.Value);
                if (result.Correct)
                {
                    libro = ((ML.Libro)result.Object);
                    libro.Libros = result.Objects;
                    return View(libro);
                }
                else
                {
                    ViewBag.Mensaje = "No se encontro el registro" + result.ErrorMessage;
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            HttpPostedFileBase file = Request.Files["ImagenData"];
            if (file.ContentLength > 0)
            {
                libro.Imagen = ConvertToBytes(file);
            }
            if (libro.IdLibro == 0)
            {
                result = BL.Libro.Add(libro);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "El libro se ha registrado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "El libro no se registro correctamente";
                }
            }
            else
            {
                result = BL.Libro.Update(libro);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "El libro se actualizo correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "El libro no se actualizo correctamente";
                }
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            libro.IdLibro = IdLibro;
            ML.Result result = BL.Libro.Delete(IdLibro);
            if (result.Correct)
            {
                ViewBag.Mensaje = "El IdLibro se ha eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "El IdLibro no se ha eliminado correctamente";
            }
            return PartialView("Modal");
        }
        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }
	}
}