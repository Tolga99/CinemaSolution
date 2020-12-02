using ConsoleFilm;
using LibraryDTO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LibraryBLL
{
    public class FilmTypesDatabaseMethods
    {
        private CinemaContext CC;

        public FilmTypesDatabaseMethods()
        {

        }
        public FilmTypesDatabaseMethods(CinemaContext cc)
        {
            CC = cc;
        }
        public List<FilmTypeDTO> GetListFilmTypesByIdFilm(int id)
        {
            List<FilmTypeDTO> list = new List<FilmTypeDTO>();
            var query = from b in CC.Films.Include(a => a.FilmTypelist)//AJOUTER SYSTEM.LINQ
                        where b.FilmId == id
                        select b;

            foreach (var film in query)
            {
                foreach (var genre in film.FilmTypelist)
                    list.Add(new FilmTypeDTO(genre.Id,genre.Name));
            }
            return list; //return LES genres pour ce film
        }
    }
}
