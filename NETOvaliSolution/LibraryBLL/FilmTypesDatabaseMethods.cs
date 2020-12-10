using ConsoleFilm;
using LibraryDTO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryBD;

namespace LibraryBLL
{
    public class FilmTypesDatabaseMethods
    {
        public AccessMethods access;
        public FilmTypesDatabaseMethods()
        {
            access = new AccessMethods();
        }
        public List<FilmTypeDTO> GetListFilmTypesByIdFilm(int id)
        {
            List<FilmTypeDTO> list = new List<FilmTypeDTO>();
            //var query = from b in CC.Films.Include(a => a.FilmTypelist)//AJOUTER SYSTEM.LINQ
            //            where b.FilmId == id
            //            select b;

            var query = access.GetFilmWTypesByIdFilm(id);
            foreach (var film in query)
            {
                foreach (var genre in film.FilmTypelist)
                    list.Add(new FilmTypeDTO(genre.Id,genre.Name));
            }
            return list; //return LES genres pour ce film
        }
    }
}
