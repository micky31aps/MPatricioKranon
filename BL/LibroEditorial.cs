using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LibroEditorial
    {
        public static ML.Result LibroGetEditorial(int IdEditorial)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MPatricioKranonEntities context = new DL.MPatricioKranonEntities())
                {
                    var LibroEditorial = context.LibroGetEditorial(IdEditorial).ToList();
                    result.Objects = new List<object>();
                    if (LibroEditorial != null)
                    {
                        foreach (var obj in LibroEditorial)
                        {
                            ML.LibroEditorial editorial = new ML.LibroEditorial();
                            editorial.Libro = new ML.Libro();
                            editorial.Libro.IdLibro = obj.IdLibro.Value;
                            editorial.Libro.TituloLibro = obj.TituloLibro;
                            editorial.Libro.Imagen = obj.LibroImagen;
                            editorial.Editorial = new ML.Editorial();
                            editorial.Editorial.Nombre = obj.Nombre;
                            editorial.Editorial.Imagen = obj.EditorialImagen;
                            result.Objects.Add(editorial);
                        }
                        
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result EditorialDelete(int IdEditorial)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL.MPatricioKranonEntities context = new DL.MPatricioKranonEntities())
                {
                    var DeleteResult = context.EditorialDelete(IdEditorial);
                    if (DeleteResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se Elimino correctamente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
