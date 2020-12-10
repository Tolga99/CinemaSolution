using ConsoleFilm;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    public class AccessMethods
    {
        private CinemaContext CC;

        public AccessMethods()
        {
            DbContextOptionsBuilder<CinemaContext> optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\t_olg\\Desktop\\Ecole\\Bloc 2-3 (2020-2021)\\Q1\\DotNet\\NETOvali\\Cinema.db ;Cache=Shared");
            CC = new CinemaContext(optionsBuilder.Options);
        }
        public AccessMethods(CinemaContext cc)
        {
            CC = cc;
        }
        public IQueryable<Actor> GetAllActors() //GetFavActors & FindListFilmByName 
        {
            var query = from b in CC.Actors.Include(a => a.Films)
                       // where b.Films.Count > 2
                        select b;
            return query; 
        }
        public IQueryable<Film> GetFilmWActorsById(int ID) //Retourne un film grace a son id   && InsertComment && GetListActorsByIdFilm
        {

            var query = from b in CC.Films.Include(a => a.Actors)
                        where b.FilmId == ID
                        select b;

            return query;
        }
        public IQueryable<Film> GetFilmWComById(int ID) //Retourne un film grace a son id   && InsertComment && GetListActorsByIdFilm
        {

            var query = from b in CC.Films.Include(a => a.Comments)
                        where b.FilmId == ID
                        select b;

            return query;
        }
        public IQueryable<Film> GetFullFilmByIdFilm(int ID) //Retourne un film detaillé grace a son id
        {
            var query = from b in CC.Films.Include(a => a.Actors).Include(c => c.FilmTypelist).Include(e => e.Comments)//AJOUTER SYSTEM.LINQ
                        where b.FilmId == ID
                        select b;
            return query;

        }
        public IQueryable<Film> GetFilmWTypesByIdFilm(int id) //GetListFilmTypesByIdFilm
        {
            var query = from b in CC.Films.Include(a => a.FilmTypelist)//AJOUTER SYSTEM.LINQ
                        where b.FilmId == id
                        select b;

            return query;
        }
        public int FindLastId() //Comments
        {
            int max = CC.Comments.Max(i => i.Id);//AJOUTER SYSTEM.LINQ

            return max + 1;
        }
        public void AddComment(Film film,Comment cmt)
        {
            CC.Comments.Add(cmt);
            film.Comments.Add(cmt);
            CC.SaveChanges();
        }
        public IQueryable<Actor> GetActorById(int Id)
        {
            var query = from b in CC.Actors.Include(a => a.Films)//AJOUTER SYSTEM.LINQ
                        where b.ActorId == Id
                        select b;

            return query;
        }
    }
}
