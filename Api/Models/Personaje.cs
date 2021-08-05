using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Personaje
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public int Edad { get; set; }
        public int Peso { get; set; }
        public string Historia { get; set; }
        public int IdPelicula { get; set; }
        public List<PeliculaSerie> Peliculas { get; set; }
        public void Agregar(Personaje personaje)
        {
            List<Datos.Parametro> parametros = new List<Datos.Parametro>
            {
                new Datos.Parametro("@Nombre", personaje.Nombre),
                new Datos.Parametro("@Imagen", personaje.Imagen),
                new Datos.Parametro("@Edad", personaje.Edad),
                new Datos.Parametro("@Peso", personaje.Peso),
                new Datos.Parametro("@Historia", personaje.Historia)
            };
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            datos.EjecutarProcedimiento("sp_InsertarPersonaje", parametros);
            
        }
        public void Eliminar(Personaje personaje)
        {
            
            List<Datos.Parametro> parametros = new List<Datos.Parametro>
            {
                new Datos.Parametro("@Id", personaje.Id)
            };
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            datos.EjecutarProcedimiento("sp_EliminarPersonajexId", parametros);
        }
        public void Editar(Personaje personaje)
        {

            List<Datos.Parametro> parametros = new List<Datos.Parametro>
            {
                new Datos.Parametro("@Id", personaje.Id),
                new Datos.Parametro("@Nombre", personaje.Nombre),
                new Datos.Parametro("@Imagen", personaje.Imagen),
                new Datos.Parametro("@Edad", personaje.Edad),
                new Datos.Parametro("@Peso", personaje.Peso),
                new Datos.Parametro("@Historia", personaje.Historia)
            };
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            datos.EjecutarProcedimiento("sp_EditarPersonajexId", parametros);
        }
        public Personaje Detalle(Personaje personaje)
        {
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            List<Personaje> lista = new List<Personaje>();
            try
            {
                datos.setearConsulta("select * from Personajes where id=" + personaje.Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Personaje aux = new Personaje();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Edad = (int)datos.Lector["Edad"];
                    aux.Peso = (int)datos.Lector["Peso"];
                    aux.Imagen = (string)datos.Lector["Imagen"];
                    aux.Historia = (string)datos.Lector["Historia"];

                    personaje = aux;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            return personaje;
        }
        public List<Personaje> Listar()
        {
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            List<Personaje> lista = new List<Personaje>();
            try
            {
                datos.setearConsulta("select * from Personajes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Personaje aux = new Personaje();
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Imagen = (string)datos.Lector["Imagen"];
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
        public List<Personaje> ListarCompleto()
        {
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            List<Personaje> lista = new List<Personaje>();
            try
            {
                datos.setearConsulta("select * from Personajes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Personaje aux = new Personaje();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Edad = (int)datos.Lector["Edad"];
                    aux.Peso = (int)datos.Lector["Peso"];
                    aux.Imagen = (string)datos.Lector["Imagen"];
                    aux.Historia = (string)datos.Lector["Historia"];

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

        public List<PeliculaSerie> PeliculasXPersonaje(Personaje personaje)
        {
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
            List<PeliculaSerie> lista = new List<PeliculaSerie>();
            datos.setearConsulta("select p.id, p.Imagen, p.Titulo, p.FechaCreacion, p.Calificacion, per.Nombre from Peliculas_Series p " +
                                "join Personajes_x_PoS pp on pp.IdPelicula = p.Id " +
                                "join Personajes per on per.Id = pp.IdPersonaje where per.id = "+ personaje.Id);
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                PeliculaSerie aux = new PeliculaSerie();

                aux.Id = (int)datos.Lector["Id"];
                aux.Titulo = (string)datos.Lector["Titulo"];
                aux.Imagen = (string)datos.Lector["Imagen"];
                aux.Calificacion = (int)datos.Lector["Calificacion"];
                aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                lista.Add(aux);
            }


            return lista;
        }

        //En estos filtros muestro solamente Nombre e Imagen porque es lo que se pide en el Punto 3 (listado de personajes). Al menos asi lo entendi yo

        public List<Personaje> FiltroNombre(string nombre)
        {
            List<Personaje> lista = new List<Personaje>();
            Datos.AccesoDatos datos = new Datos.AccesoDatos();
           
            try
            {
                datos.setearConsulta("select * from Personajes where Nombre LIKE '%"+ nombre +"%'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Personaje aux = new Personaje();

                   
                    aux.Nombre = (string)datos.Lector["Nombre"];
                   
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
        public List<Personaje> FiltroEdad(int edad)
        {
            List<Personaje> lista = new List<Personaje>();
            Datos.AccesoDatos datos = new Datos.AccesoDatos();

            try
            {
                datos.setearConsulta("select * from Personajes where Edad= " + edad );
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Personaje aux = new Personaje();

                   
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    
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
        public List<Personaje> FiltroPelicula(int idPelicula)
        {
            List<Personaje> lista = new List<Personaje>();
            Datos.AccesoDatos datos = new Datos.AccesoDatos();

            try
            {
                datos.setearConsulta("select per.Id, per.Nombre, per.Imagen, per.Edad, per.Peso, per.Historia from Personajes per " +
                    "join Personajes_x_PoS pp on pp.IdPersonaje = per.Id " +
                    "join Peliculas_Series ps on ps.Id = pp.IdPelicula " +
                    "where ps.Id =" + idPelicula);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Personaje aux = new Personaje();

                   
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    
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
