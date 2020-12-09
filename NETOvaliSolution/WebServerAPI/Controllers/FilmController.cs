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
        [HttpGet("FindListFilmPartActor/{name}")]
        public IEnumerable<FilmDTO> FindListFilmByPartialActorName(string name)
        {
            FilmsDatabaseMethods fdm = new FilmsDatabaseMethods();
            return fdm.FindListFilmByPartialActorName(name);
        }

        [HttpGet("FindListFilmFullActor/{name}/{surname}")]
        public IEnumerable<FilmDTO> FindListFilmByFullActorName(string name,string surname)
        {
            FilmsDatabaseMethods fdm = new FilmsDatabaseMethods();
            return fdm.FindListFilmByFullActorName(name,surname);
        }

        [HttpGet("GetFFD/{id}")]
        public List<FullFilmDTO> GetFullFilmDetailsByIdFilm(int id)
        {
            FilmsDatabaseMethods fdm = new FilmsDatabaseMethods();
            List<FullFilmDTO> ffl = new List<FullFilmDTO>();
            ffl.Add(fdm.GetFullFilmDetailsByIdFilm(id));
            
            return ffl ;
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
