using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryBD;
using LibraryBLL;
using LibraryDTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
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
        public IEnumerable<FullFilmDTO> GetFullFilmDetailsByIdFilm(int id, [FromQuery] int page, [FromQuery] int pagesize)
        {
            if (id<=0 || id>int.MaxValue)
            {
                return (IEnumerable<FullFilmDTO>)BadRequest(new BadRequestError("Id of film is an invalid number"));
            }
            PagingParameterModel pagingparametermodel = new PagingParameterModel();
            pagingparametermodel.pageNumber = page;
            pagingparametermodel.pageSize = pagesize;

            FilmsDatabaseMethods fdm = new FilmsDatabaseMethods();
            List<FullFilmDTO> l = fdm.GetFullFilmDetailsByIdFilm(id);
            List<LightActorDTO> actors = new List<LightActorDTO>();
            foreach(FullFilmDTO f in l)
            {
                
                foreach(LightActorDTO act in f.Actors)
                {
                    actors.Add(act);
                }
                f.Actors.Clear();
            }
            int count = actors.Count;
            int CurrentPage = pagingparametermodel.pageNumber;
            int PageSize = pagingparametermodel.pageSize;
            int TotalCount = count;

            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            List<LightActorDTO> items = actors.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            var previousPage = CurrentPage > 1 ? "Yes" : "No";

            var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

            var paginationMetadata = new
            {
                totalCount = TotalCount,
                pageSize = PageSize,
                currentPage = CurrentPage,
                totalPages = TotalPages,
                previousPage,
                nextPage
            };
            foreach(LightActorDTO actor in items)
            {
                l.FirstOrDefault().Actors.Add(actor);
            }
            if (id<0) return (IEnumerable<FullFilmDTO>)NotFound(new NotFoundError("Film introuvable"));
            else
            {
                return l;
            }

        }
        [HttpGet("all")]
        public IEnumerable<FullFilmDTO> GetAllFilms([FromQuery] int page, [FromQuery] int pagesize)
        {
            PagingParameterModel pagingparametermodel = new PagingParameterModel();
            pagingparametermodel.pageNumber = page;
            pagingparametermodel.pageSize = pagesize;

            FilmsDatabaseMethods fdm = new FilmsDatabaseMethods();
            List<FullFilmDTO> l = fdm.GetAllFilms();
            List<LightActorDTO> actors = new List<LightActorDTO>();
            foreach (FullFilmDTO f in l)
            {

                foreach (LightActorDTO act in f.Actors)
                {
                    actors.Add(act);
                }
                f.Actors.Clear();
            }
            int count = l.Count;
            int CurrentPage = pagingparametermodel.pageNumber;
            int PageSize = pagingparametermodel.pageSize;
            int TotalCount = count;

            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            List<FullFilmDTO> items = l.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

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
            return items;

        }

        [HttpPost("name")]
        public FullFilmDTO GetFilmByTitle([FromBody] string title)
        {
            FilmsDatabaseMethods fdm = new FilmsDatabaseMethods();
            FullFilmDTO l = fdm.GetFilmByTitle(title);
            if (l.Title == null)
                return null;
            else return l;
        }
    }
}
