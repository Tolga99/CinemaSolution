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
        [HttpGet("{id}")]
        public IActionResult GetListFilmTypesByIdFilm(int id)
        {
            if (id <= 0 || id > int.MaxValue)
            {
                return BadRequest(new BadRequestError("Id of film is an invalid number"));
            }
            FilmTypesDatabaseMethods ftdm = new FilmTypesDatabaseMethods();
            List<FilmTypeDTO>l= ftdm.GetListFilmTypesByIdFilm(id);
            if (l.Count == 0)
                return NotFound(new NotFoundError("Film introuvable ou Type du film manquant"));
            else return Ok(l);
        }
    }
}
