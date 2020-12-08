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
    public class ActorController : ControllerBase
    {
        // GET: api/<ActorController>
        [HttpGet("favactors")]
        public IEnumerable<ActorDTO> GetFavoriteActors()
        {
            ActorsDatabaseMethods adm = new ActorsDatabaseMethods();
            return adm.GetFavoriteActors();
        }

        [HttpGet("actbyidf/{id}")]
        public List<LightActorDTO> GetListActorsByIdFilm(int id)
        {
            ActorsDatabaseMethods adm = new ActorsDatabaseMethods();
            return adm.GetListActorsByIdFilm(id);
        }

        // POST api/<ActorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
