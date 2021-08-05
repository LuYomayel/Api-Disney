using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class PeliculaSerie
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Calificacion { get; set; }
        public Genero genero { get; set; }
        public List<Personaje> Personajes { get; set; }

        public List<PeliculaSerie> Listar()
        {
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            List<PeliculaSerie> lista = new List<PeliculaSerie>();
            try
            {
                datos.setearConsulta("select * from Peliculas_Series");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    PeliculaSerie aux = new PeliculaSerie();
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Imagen = (string)datos.Lector["Imagen"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void Agregar(PeliculaSerie movie)
        {
            
            List<Datos.Parametro> parametros = new List<Datos.Parametro>
            {
                new Datos.Parametro("@Imagen", movie.Imagen),
                new Datos.Parametro("@Titulo", movie.Titulo),
                new Datos.Parametro("@FechaCreacion", movie.FechaCreacion),
                new Datos.Parametro("@Calificacion", movie.Calificacion),
                new Datos.Parametro("@IdGenero", movie.genero.Id)
            };
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            datos.EjecutarProcedimiento("sp_InsertarPelicula", parametros);

        }
        public void Eliminar(PeliculaSerie movie)
        {

            List<Datos.Parametro> parametros = new List<Datos.Parametro>
            {
                new Datos.Parametro("@Id", movie.Id)
                
            };
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            datos.EjecutarProcedimiento("sp_EliminarPeliculaSerie", parametros);

        }
        public void Editar(PeliculaSerie movie)
        {
            
            List<Datos.Parametro> parametros = new List<Datos.Parametro>
            {
                new Datos.Parametro("@Id", movie.Id),
                new Datos.Parametro("@Imagen", movie.Imagen),
                new Datos.Parametro("@Titulo", movie.Titulo),
                new Datos.Parametro("@FechaCreacion", movie.FechaCreacion),
                new Datos.Parametro("@Calificacion", movie.Calificacion),
                new Datos.Parametro("@IdGenero", movie.genero.Id)
            };
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            datos.EjecutarProcedimiento("sp_EditarPeliculaSerie", parametros);

        }
        public PeliculaSerie Leer(PeliculaSerie movie)
        {
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            
            try
            {
                datos.setearConsulta("select p.Id, p.Imagen, p.Titulo, p.Calificacion,p.FechaCreacion, g.Nombre Genero from Peliculas_Series p join Generos g on g.id = p.IdGenero where p.id=" + movie.Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    PeliculaSerie aux = new PeliculaSerie();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Imagen = (string)datos.Lector["Imagen"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.Calificacion = (int)datos.Lector["Calificacion"];
                    aux.genero = new Genero();
                    aux.genero.Nombre = (string)datos.Lector["Genero"];

                    movie = aux;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return movie;
        }
        public PeliculaSerie Detalle(PeliculaSerie movie)
        {
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            
            try
            {
                datos.setearConsulta("select p.Id, p.Imagen, p.Titulo, p.Calificacion,p.FechaCreacion, g.Nombre Genero from Peliculas_Series p join Generos g on g.id = p.IdGenero where p.id=" + movie.Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    PeliculaSerie aux = new PeliculaSerie();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Imagen = (string)datos.Lector["Imagen"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.Calificacion = (int)datos.Lector["Calificacion"];
                    aux.genero = new Genero();
                    aux.genero.Nombre = (string)datos.Lector["Genero"];

                    movie = aux;
                }
               
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
            return movie;
        }
        public List<Personaje> PersonajesXPelicula(PeliculaSerie movie)
        {
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            List<Personaje> lista = new List<Personaje>();
            datos.setearConsulta("select per.Id, per.Nombre, per.Imagen from Peliculas_Series p join Personajes_x_PoS pp on pp.IdPelicula = p.Id " +
                                   "join Personajes per on per.Id = pp.IdPersonaje " +
                                   "where p.id=" + movie.Id);
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                PeliculaSerie aux = new PeliculaSerie();
                Personaje personaje = new Personaje();
                
                personaje.Nombre = (string)datos.Lector["Nombre"];
                lista.Add(personaje);
            }


            return lista;
        }


        public List<PeliculaSerie> FiltroTitulo(string nombre)
        {
            List<PeliculaSerie> lista = new List<PeliculaSerie>();
            Datos.AccesoDatos datos = new Datos.AccesoDatos();

            try
            {
                datos.setearConsulta("select * from Peliculas_Series where Titulo LIKE '%" + nombre + "%'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    PeliculaSerie aux = new PeliculaSerie();
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.Imagen = (string)datos.Lector["Imagen"];
                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }
        public List<PeliculaSerie> FiltroGenero(int id)
        {
            List<PeliculaSerie> lista = new List<PeliculaSerie>();
            Datos.AccesoDatos datos = new Datos.AccesoDatos();

            try
            {
                datos.setearConsulta("select * from Peliculas_Series where IdGenero=" + id );
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    PeliculaSerie aux = new PeliculaSerie();
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.Imagen = (string)datos.Lector["Imagen"];
                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }
    }
}
