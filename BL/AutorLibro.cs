using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AutorLibro
    {
        public static ML.Result GetAutor(int IdAutor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MPatricioKranonEntities context = new DL.MPatricioKranonEntities())
                {
                    var GetAutor = context.LibroGetAutor(IdAutor).ToList();
                    result.Objects = new List<object>();

                    if (GetAutor != null)
                    {
                        foreach (var obj in GetAutor)
                        {
                            ML.Libro libro = new ML.Libro();
                            libro.IdLibro = obj.IdLibro;
                            libro.TituloLibro = obj.TituloLibro;
                            libro.AñoPublicacion = obj.AñoPublicacion.Value;
                            libro.Imagen = obj.Imagen;
                            //autor.Autor = new ML.Autor();
                            //autor.Autor.Nombre = GetAutor.Nombre;
                            //autor.Autor.ApellidoPaterno = GetAutor.ApellidoPaterno;
                            result.Objects.Add (libro);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro";
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
        public static ML.Result AutorGetFecha(int IdAutor, short AñoPublicacion)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MPatricioKranonEntities context = new DL.MPatricioKranonEntities())
                {
                    var GetTitulo = context.AutorGetFecha(IdAutor, AñoPublicacion).FirstOrDefault();

                    result.Object = new List<object>();
                    if (GetTitulo != null)
                    {
                        ML.Libro libroresult = new ML.Libro();
                        libroresult.IdLibro = GetTitulo.IdLibro.Value;
                        libroresult.TituloLibro = GetTitulo.TituloLibro;
                        libroresult.AñoPublicacion = GetTitulo.AñoPublicacion.Value;
                        libroresult.Imagen = GetTitulo.Imagen;
                        result.Object = libroresult;
                        result.Correct = true;

                    }
                    else
                    {


                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro";
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

        public static ML.Result AutorDelete(int IdAutor)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL.MPatricioKranonEntities context = new DL.MPatricioKranonEntities())
                {
                    var DeleteResult = context.AutorDelete(IdAutor);
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
