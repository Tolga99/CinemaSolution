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
    public class CommentController : ControllerBase
    {
        // GET: api/<CommentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CommentController>/5
        [HttpGet("film/{id}")]
        public IEnumerable<CommentDTO> Get(int id)
        {
            CommentsDatabaseMethods cdm = new CommentsDatabaseMethods();
            List<CommentDTO> comments= cdm.GetCommentsOnFilmId(id);
            return comments;
        }

        // POST api/<CommentController>
        [HttpPost("film/{idFilm}")]
        public void Post([FromBody] string contenu,int idFilm, [FromQuery] int note, [FromQuery] string user) //FROM  Query
        {
            CommentsDatabaseMethods cdm = new CommentsDatabaseMethods();
            cdm.InsertCommentOnFilmId(idFilm, contenu, note, user);
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
