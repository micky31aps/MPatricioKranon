using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MPatricioKranonEntities context = new DL.MPatricioKranonEntities())
                {
                    var GetByIdResult = context.GetByIdLibro(IdLibro).FirstOrDefault();
                    if (GetByIdResult != null)
                    {
                        ML.Libro libro = new ML.Libro();
                        libro.IdLibro = GetByIdResult.IdLibro;
                        libro.TituloLibro = GetByIdResult.TituloLibro;
                        libro.AñoPublicacion = GetByIdResult.AñoPublicacion.Value;
                        libro.Imagen = GetByIdResult.Imagen;
                        result.Object = libro;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro ningun registro";
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
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MPatricioKranonEntities context = new DL.MPatricioKranonEntities())
                {
                    var AddResult = context.LibroAdd(libro.TituloLibro, libro.AñoPublicacion, libro.Imagen);
                    if (AddResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto correctamente el registro";
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
        public static ML.Result GetTitulo (ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MPatricioKranonEntities context = new DL.MPatricioKranonEntities())
                {
                    if (libro.TituloLibro == "1" || libro.TituloLibro == null)
                    {
                        libro.TituloLibro = "";
                    }
                    var GetTitulo = context.TituloGet(libro.TituloLibro).ToList();

                    result.Objects = new List<object>();
                    if (GetTitulo != null)
                    {
                        foreach (var obj in GetTitulo)
                        {
                            ML.Libro libroresult = new ML.Libro();
                            libroresult.IdLibro = obj.IdLibro;
                            libroresult.TituloLibro = obj.TituloLibro;
                            libroresult.AñoPublicacion = obj.AñoPublicacion.Value;
                            libroresult.Imagen = obj.Imagen;
                            result.Objects.Add(libroresult);
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
        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL.MPatricioKranonEntities context = new DL.MPatricioKranonEntities())
                {
                    var updateResult = context.UpdateLibro(libro.IdLibro, libro.TituloLibro, libro.AñoPublicacion, libro.Imagen);
                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó los datos ingresados";
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
        public static ML.Result Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL.MPatricioKranonEntities context = new DL.MPatricioKranonEntities())
                {
                    var DeleteResult = context.DeleteLibro(IdLibro);
                    if (DeleteResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se Elimino los datos ingresados";
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
