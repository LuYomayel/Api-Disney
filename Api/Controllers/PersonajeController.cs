using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Api.Controllers
{
    
    public class PersonajeController : ControllerBase
    {
        [Route("characters")]
        [HttpGet]
        public dynamic Filtro(Models.Personaje personaje)
        {
            List<Models.Personaje> lista = new List<Models.Personaje>();
            if (personaje.Nombre != null)
            {
                lista = personaje.FiltroNombre(personaje.Nombre);
                if (lista != null)
                {
                    return lista;
                }
                else
                {
                    return "no hay personajes con ese nombre";
                }
            }
            else if (personaje.Edad != 0)
            {
                lista = personaje.FiltroEdad(personaje.Edad);
                if (lista != null)
                {
                    return lista;
                }
                else
                {
                    return "no hay personajes con esa edad";
                }
            }
            else if (personaje.IdPelicula != 0)
            {
                lista = personaje.FiltroPelicula(personaje.IdPelicula);
                if (lista != null)
                {
                    return lista;
                }
                else
                {
                    return "no hay personajes con esa Pelicula";
                }
            }
            else
            {
                return lista = personaje.Listar();
            }

        }



        [Route("characters/add")]
        [HttpPost]
        public void Agregar(Models.Personaje personaje)
        {
            
            personaje.Agregar(personaje);
            
        }




        [Route("characters/delete")]
        [HttpDelete]
        public void Eliminar(Models.Personaje personaje)
        {

            personaje.Eliminar(personaje);

        }



        [Route("characters/edit")]
        [HttpPut]
        public void Editar(Models.Personaje personaje)
        {

            personaje.Editar(personaje);

        }



        [Route("characters/detail")]
        [HttpGet]
        public dynamic Detalle(Models.Personaje personaje)
        {
            
            personaje = personaje.Detalle(personaje);
            if (personaje.Nombre == null)
            {
                return "No hay Personajes con ese Id";
            }
            personaje.Peliculas = personaje.PeliculasXPersonaje(personaje);

            return personaje;
        }



        
    }
}
