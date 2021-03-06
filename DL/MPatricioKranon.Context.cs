//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MPatricioKranonEntities : DbContext
    {
        public MPatricioKranonEntities()
            : base("name=MPatricioKranonEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<AutorLibro> AutorLibroes { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }
        public virtual DbSet<Libro> Libroes { get; set; }
        public virtual DbSet<LibroEditorial> LibroEditorials { get; set; }
    
        public virtual ObjectResult<AñoPublicacionGet_Result> AñoPublicacionGet(Nullable<short> añoPublicacion)
        {
            var añoPublicacionParameter = añoPublicacion.HasValue ?
                new ObjectParameter("AñoPublicacion", añoPublicacion) :
                new ObjectParameter("AñoPublicacion", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AñoPublicacionGet_Result>("AñoPublicacionGet", añoPublicacionParameter);
        }
    
        public virtual int AutorDelete(Nullable<int> idAutorLibro)
        {
            var idAutorLibroParameter = idAutorLibro.HasValue ?
                new ObjectParameter("IdAutorLibro", idAutorLibro) :
                new ObjectParameter("IdAutorLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutorDelete", idAutorLibroParameter);
        }
    
        public virtual ObjectResult<AutorGetFecha_Result> AutorGetFecha(Nullable<int> idAutor, Nullable<short> añoPublicacion)
        {
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            var añoPublicacionParameter = añoPublicacion.HasValue ?
                new ObjectParameter("AñoPublicacion", añoPublicacion) :
                new ObjectParameter("AñoPublicacion", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AutorGetFecha_Result>("AutorGetFecha", idAutorParameter, añoPublicacionParameter);
        }
    
        public virtual int EditorialDelete(Nullable<int> idLibroEditorial)
        {
            var idLibroEditorialParameter = idLibroEditorial.HasValue ?
                new ObjectParameter("IdLibroEditorial", idLibroEditorial) :
                new ObjectParameter("IdLibroEditorial", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditorialDelete", idLibroEditorialParameter);
        }
    
        public virtual int LibroAdd(string tituloLibro, Nullable<short> añoPublicacion, byte[] imagen)
        {
            var tituloLibroParameter = tituloLibro != null ?
                new ObjectParameter("TituloLibro", tituloLibro) :
                new ObjectParameter("TituloLibro", typeof(string));
    
            var añoPublicacionParameter = añoPublicacion.HasValue ?
                new ObjectParameter("AñoPublicacion", añoPublicacion) :
                new ObjectParameter("AñoPublicacion", typeof(short));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroAdd", tituloLibroParameter, añoPublicacionParameter, imagenParameter);
        }
    
        public virtual ObjectResult<LibroGetAutor_Result> LibroGetAutor(Nullable<int> idAutor)
        {
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetAutor_Result>("LibroGetAutor", idAutorParameter);
        }
    
        public virtual ObjectResult<LibroGetEditorial_Result1> LibroGetEditorial(Nullable<int> idEditorial)
        {
            var idEditorialParameter = idEditorial.HasValue ?
                new ObjectParameter("IdEditorial", idEditorial) :
                new ObjectParameter("IdEditorial", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetEditorial_Result1>("LibroGetEditorial", idEditorialParameter);
        }
    
        public virtual int DeleteLibro(Nullable<int> idLibro)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteLibro", idLibroParameter);
        }
    
        public virtual int UpdateLibro(Nullable<int> idLibro, string tituloLibro, Nullable<short> añoPublicacion, byte[] imagen)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            var tituloLibroParameter = tituloLibro != null ?
                new ObjectParameter("TituloLibro", tituloLibro) :
                new ObjectParameter("TituloLibro", typeof(string));
    
            var añoPublicacionParameter = añoPublicacion.HasValue ?
                new ObjectParameter("AñoPublicacion", añoPublicacion) :
                new ObjectParameter("AñoPublicacion", typeof(short));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateLibro", idLibroParameter, tituloLibroParameter, añoPublicacionParameter, imagenParameter);
        }
    
        public virtual ObjectResult<GetAllLibro_Result1> GetAllLibro()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllLibro_Result1>("GetAllLibro");
        }
    
        public virtual ObjectResult<GetByIdLibro_Result2> GetByIdLibro(Nullable<int> idLibro)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByIdLibro_Result2>("GetByIdLibro", idLibroParameter);
        }
    
        public virtual ObjectResult<GetAllAutor_Result> GetAllAutor()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllAutor_Result>("GetAllAutor");
        }
    
        public virtual ObjectResult<TituloGet_Result> TituloGet(string tituloLibro)
        {
            var tituloLibroParameter = tituloLibro != null ?
                new ObjectParameter("TituloLibro", tituloLibro) :
                new ObjectParameter("TituloLibro", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TituloGet_Result>("TituloGet", tituloLibroParameter);
        }
    }
}
