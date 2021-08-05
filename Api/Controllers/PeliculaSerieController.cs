using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    
    public class PeliculaSerieController : ControllerBase
    {
        [Route("movies")]
        [HttpGet]
        public dynamic Listar(Models.PeliculaSerie pelicula)
        {
            Models.PeliculaSerie movie = new Models.PeliculaSerie();
            List<Models.PeliculaSerie> lista = new List<Models.PeliculaSerie>();
            if(pelicula.Titulo != null)
            {
                lista = pelicula.FiltroTitulo(pelicula.Titulo);
                if(lista != null)
                {
                    return lista;
                }
                else
                {
                    return "no se encontraron peliculas con ese titulo";
                }
            }
            else if (pelicula.genero != null)
            {
                lista = pelicula.FiltroGenero(pelicula.genero.Id);
                if (lista != null)
                {
                    return lista;
                }
                else
                {
                    return "no se encontraron peliculas con ese titulo";
                }
            }
            
            else
            {
                return movie.Listar();
            }
            
        }


        [Route("movies/add")]
        [HttpPost]
        public void Agregar([FromBody] Models.PeliculaSerie movie)
        {
            Models.PeliculaSerie nueva = new Models.PeliculaSerie();
            nueva.Imagen = movie.Imagen;
            nueva.Titulo = movie.Titulo;
            nueva.FechaCreacion = movie.FechaCreacion;
            nueva.genero = new Models.Genero();
            nueva.genero.Id = movie.genero.Id;
            nueva.Calificacion = movie.Calificacion;
            
            nueva.Agregar(nueva);
        }


        [Route("movies/delete")]
        [HttpDelete]
        public void Eliminar([FromBody]Models.PeliculaSerie movie)
        {
            Models.PeliculaSerie nueva = new Models.PeliculaSerie();
            nueva.Id = movie.Id;
            nueva.Eliminar(nueva);
        }


        [Route("movies/edit")]
        [HttpPut]
        public void Editar(Models.PeliculaSerie movie)
        {
            movie.Editar(movie);
        }


        /*  Lo habia hecho antes del detalle y bueno, quedó...
           
        [Route("movies/read")]
        [HttpGet]
        public dynamic Leer(Models.PeliculaSerie movie)
        {
            movie = movie.Leer(movie);
            


            return movie.Leer(movie);
        }*/


        [Route("movies/detail")]
        [HttpGet]
        public dynamic Detalle(Models.PeliculaSerie movie)
        {
            movie = movie.Detalle(movie);
            movie.Personajes = movie.PersonajesXPelicula(movie);
            return movie;
        }
    }
}
