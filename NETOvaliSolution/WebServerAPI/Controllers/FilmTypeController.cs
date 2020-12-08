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
    public class FilmTypeController : ControllerBase
    {
        // GET: api/<FilmTypeController>
        [HttpGet("ft/{id}")]
        public IEnumerable<FilmTypeDTO> GetListFilmTypesByIdFilm(int id)
        {
            FilmTypesDatabaseMethods ftdm = new FilmTypesDatabaseMethods();
            return ftdm.GetListFilmTypesByIdFilm(id);
        }

        // GET api/<FilmTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FilmTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FilmTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FilmTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
