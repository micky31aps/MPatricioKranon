using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AutorLibroController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Autor autor = new ML.Autor();
            ML.Result result = BL.Autor.GetAll();
            if(result.Correct)
            {
                autor.Autores = result.Objects;
            }
            else
            {

            }
            return View(autor);
        }
        [HttpPost]
        public ActionResult AutorGetLibro(int IdAutor)
        {
            ML.Libro libro = new ML.Libro();
            libro.Libros = new List<object>();
            using (var client = new HttpClient())
            {
                string UrlApi = System.Configuration.ConfigurationManager.AppSettings["WebAPI"].ToString();
                client.BaseAddress = new Uri(UrlApi);
                var responseTask = client.GetAsync("AutorLibro/GetByAutor/" + IdAutor);
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
        
	}
}