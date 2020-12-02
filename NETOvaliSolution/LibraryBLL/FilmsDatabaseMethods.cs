using ConsoleFilm;
using LibraryDTO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LibraryBLL
{
    public class FilmsDatabaseMethods
    {
        private CinemaContext CC;

        public FilmsDatabaseMethods()
        {

        }
        public FilmsDatabaseMethods(CinemaContext cc)
        {
            CC = cc;
        }
        public List<FilmDTO> FindListFilmByPartialActorName(string name)
        {
            List<FilmDTO> list = new List<FilmDTO>();

            var query = from b in CC.Actors.Include(a => a.Films)//AJOUTER SYSTEM.LINQ
                         where b.Name==name
                        select b;

            foreach (var actor in query)
            {
                foreach (var film in actor.Films)
                    list.Add(new FilmDTO(film.FilmId, film.Title, film.Release_Date, film.Vote_Average, film.Runtime, film.Posterpath));
            }
            return list; // return les films legers ds lequel l'acteur a jouer 
        }
        public FullFilmDTO GetFullFilmDetailsByIdFilm(int id)
        {
            FullFilmDTO full=new FullFilmDTO();
            var query = from b in CC.Films.Include(a => a.Actors).Include(c => c.FilmTypelist).Include(e => e.Comments)//AJOUTER SYSTEM.LINQ
                        where b.FilmId == id
                        select b;
            foreach (var film in query)
                full = new FullFilmDTO(film.FilmId, film.Title, film.Release_Date, film.Vote_Average, film.Runtime, film.Posterpath, film.FilmTypelist, film.Actors);
            return full; //return les infos completes d'un film + des infos complementaires
        }
    }
}
