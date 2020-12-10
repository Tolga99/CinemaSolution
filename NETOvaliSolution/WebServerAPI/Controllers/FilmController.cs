using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryBLL;
using LibraryDTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        // GET: api/<FilmController>
       /* [HttpGet("name")]
        public IActionResult FindListFilmByPartialActorName([FromQuery]string name)
        {
            FilmsDatabaseMethods fdm = new FilmsDatabaseMethods();
            List<FilmDTO>l= fdm.FindListFilmByPartialActorName(name);
            if (l.Count == 0)
                return NotFound(new NotFoundError("Film ou Acteur introuvable"));
            else return Ok(l); 
        }
       */
        [HttpGet("name")]
        public IActionResult FindListFilmByFullActorName([FromQuery]string name, [FromQuery] string surname="") //Ajouter 2 param de Page
        {
            FilmsDatabaseMethods fdm = new FilmsDatabaseMethods();
            List<FilmDTO> l;
            if (surname == "")
            {
                l = fdm.FindListFilmByPartialActorName(name);
            }
            else
                l = fdm.FindListFilmByFullActorName(name, surname);
            if (l.Count == 0)
                return NotFound(new NotFoundError("Film ou Acteur introuvable"));
            else return Ok(l);
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmByIdFilm(int id)
        {
            if (id <= 0 || id > int.MaxValue)
            {
                return BadRequest(new BadRequestError("Id of film is an invalid number"));
            }

            FilmsDatabaseMethods fdm = new FilmsDatabaseMethods();
            FilmDTO l = fdm.FindFilmWComById(id);
            if (l.Title==null)
                return NotFound(new NotFoundError("Film introuvable"));
            else return Ok(l);
        }
        [HttpGet("{id}/details")]
        public IActionResult GetFullFilmDetailsByIdFilm(int id)
        {
            if (id<=0 || id>int.MaxValue)
            {
                return BadRequest(new BadRequestError("Id of film is an invalid number"));
            }

            FilmsDatabaseMethods fdm = new FilmsDatabaseMethods();
            FullFilmDTO l = fdm.GetFullFilmDetailsByIdFilm(id);
            if (l.Title==null && l.Actors.Count==0)
                return NotFound(new NotFoundError("Film introuvable"));
            else return Ok(l);
        }
        
        //List<FilmDTO> FindListFilmByPartialActorName(string name)
        //// GET api/<FilmController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<FilmController>/{id_film}/{comment}/{note}

        //// PUT api/<FilmController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<FilmController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
