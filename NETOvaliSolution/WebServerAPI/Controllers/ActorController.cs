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
        public IActionResult GetFavoriteActors()
        {
            ActorsDatabaseMethods adm = new ActorsDatabaseMethods();
            List<ActorDTO>l= adm.GetFavoriteActors();
            if (l.Count == 0)
                return NotFound(new NotFoundError("Aucuns acteurs n'a joué plus de 2 films"));
            else return Ok(l);
        }


        /* public List<LightActorDTO> GetListActorsByIdFilm(int id)
         {
             ActorsDatabaseMethods adm = new ActorsDatabaseMethods();
             return adm.GetListActorsByIdFilm(id);
         }
 */
        [HttpGet("actbyidf/{id}")]
        public IActionResult GetListActorsByIdFilm(int id)
        {
            if (id <= 0 || id > int.MaxValue)
            {
                return BadRequest(new BadRequestError("Id of film is an invalid number"));
            }

            ActorsDatabaseMethods adm = new ActorsDatabaseMethods();
            List<LightActorDTO>l= adm.GetListActorsByIdFilm(id);
            if (l.Count == 0)
                return NotFound(new NotFoundError("Film introuvable"));
            else return Ok(l);
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
