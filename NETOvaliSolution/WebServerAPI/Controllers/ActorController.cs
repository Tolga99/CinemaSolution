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
        [HttpGet("favorites")]
        public IActionResult GetFavoriteActors([FromQuery] int page, [FromQuery] int pagesize)
        {
            PagingParameterModel pagingParameter = new PagingParameterModel();
            pagingParameter.pageNumber = page;
            pagingParameter.pageSize = pagesize;
            ActorsDatabaseMethods adm = new ActorsDatabaseMethods();
            List<ActorDTO>l= adm.GetFavoriteActors();

            int count = l.Count;
            int CurrentPage = pagingParameter.pageNumber;
            int PageSize = pagingParameter.pageSize;
            int TotalCount = count;
            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            List<ActorDTO> items = l.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            // if CurrentPage is greater than 1 means it has previousPage  
            var previousPage = CurrentPage > 1 ? "Yes" : "No";

            // if TotalPages is greater than CurrentPage means it has nextPage  
            var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

            // Object which we are going to send in header   
            var paginationMetadata = new
            {
                totalCount = TotalCount,
                pageSize = PageSize,
                currentPage = CurrentPage,
                totalPages = TotalPages,
                previousPage,
                nextPage
            };
            if (l.Count == 0)
                return NotFound(new NotFoundError("Aucuns acteurs n'a joué plus de 2 films"));
            else return Ok(items);
        }


        /* public List<LightActorDTO> GetListActorsByIdFilm(int id)
         {
             ActorsDatabaseMethods adm = new ActorsDatabaseMethods();
             return adm.GetListActorsByIdFilm(id);
         }
 */
        [HttpGet("{id}")]
        public IActionResult GetActorById(int id)
        {
            if (id <= 0 || id > int.MaxValue)
            {
                return BadRequest(new BadRequestError("Id of actor is an invalid number"));
            }

            ActorsDatabaseMethods adm = new ActorsDatabaseMethods();
            LightActorDTO l = adm.FindActorById(id);
            if (l.Name == null)
                return NotFound(new NotFoundError("Acteur introuvable"));
            else return Ok(l);
        }

        [HttpGet("film/{id}")]
        public IActionResult GetListActorsByIdFilm(int id, [FromQuery] int page, [FromQuery] int pagesize)
        {
            if (id <= 0 || id > int.MaxValue)
            {
                return BadRequest(new BadRequestError("Id of film is an invalid number"));
            }
            PagingParameterModel pagingParameter = new PagingParameterModel();
            pagingParameter.pageNumber = page;
            pagingParameter.pageSize = pagesize;
            ActorsDatabaseMethods adm = new ActorsDatabaseMethods();
            List<LightActorDTO>l= adm.GetListActorsByIdFilm(id);

            int count = l.Count;
            int CurrentPage = pagingParameter.pageNumber;
            int PageSize = pagingParameter.pageSize;
            int TotalCount = count;
            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            List<LightActorDTO> items = l.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            // if CurrentPage is greater than 1 means it has previousPage  
            var previousPage = CurrentPage > 1 ? "Yes" : "No";

            // if TotalPages is greater than CurrentPage means it has nextPage  
            var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

            // Object which we are going to send in header   
            var paginationMetadata = new
            {
                totalCount = TotalCount,
                pageSize = PageSize,
                currentPage = CurrentPage,
                totalPages = TotalPages,
                previousPage,
                nextPage
            };

            if (l.Count == 0)
                return NotFound(new NotFoundError("Film introuvable"));
            else return Ok(items);
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
