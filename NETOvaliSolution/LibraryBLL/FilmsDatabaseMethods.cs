using ConsoleFilm;
using LibraryDTO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryBD;
using System;

namespace LibraryBLL
{
    public class FilmsDatabaseMethods
    {
        public AccessMethods access;
        public FilmsDatabaseMethods()
        {
            access = new AccessMethods();
        }

        public List<FilmDTO> FindListFilmByPartialActorName(string name)
        {
            List<FilmDTO> list = new List<FilmDTO>();

            //var query = from b in CC.Actors.Include(a => a.Films)//AJOUTER SYSTEM.LINQ
            //             where b.Name==name
            //            select b;
            var query = access.GetAllActors();
            foreach (var actor in query)
            {
                if (actor.Name == name)
                {
                    foreach (var film in actor.Films)
                        list.Add(new FilmDTO(film.FilmId, film.Title, film.Release_Date, film.Vote_Average, film.Runtime, film.Posterpath, film.Comments));
                }
            }
            return list; // return les films legers ds lequel l'acteur a jouer 
        }
        public List<FilmDTO> FindListFilmByFullActorName(string name,string surname)
        {
            List<FilmDTO> list = new List<FilmDTO>();

            //var query = from b in CC.Actors.Include(a => a.Films)//AJOUTER SYSTEM.LINQ
            //            where b.Name == name && b.Surname==surname
            //            select b;
            var query = access.GetAllActors();
            foreach (var actor in query)
            {
                if (actor.Name == name && actor.Surname == surname)
                {
                    foreach (var film in actor.Films)
                        list.Add(new FilmDTO(film.FilmId, film.Title, film.Release_Date, film.Vote_Average, film.Runtime, film.Posterpath, film.Comments));
                }
            }
            return list; // return les films legers ds lequel l'acteur a jouer 
        }
        public FilmDTO FindFilmWComById(int ID)
        {
            FilmDTO flm = null ;

            var query = access.GetFilmWComById(ID);
            foreach (var film in query)
                flm= new FilmDTO(film.FilmId, film.Title, film.Release_Date, film.Vote_Average, film.Runtime, film.Posterpath, film.Comments);
            return flm; // return les films legers ds lequel l'acteur a jouer 
        }
        public List<FullFilmDTO> GetFullFilmDetailsByIdFilm(int id)
        {

            List<FullFilmDTO> full=new List<FullFilmDTO>();
            List<LightActorDTO> lightActors = new List<LightActorDTO>();
            List<FilmTypeDTO> filmTypes = new List<FilmTypeDTO>();
            List<CommentDTO> comments = new List<CommentDTO>();
            //var query = from b in CC.Films.Include(a => a.Actors).Include(c => c.FilmTypelist).Include(e => e.Comments)//AJOUTER SYSTEM.LINQ
            //            where b.FilmId == id
            //            select b;
            //Methode d'acces au DbContext doit etre dans la DAL
            //Faire query.SKIP pour la pagination
            var query = access.GetFullFilmByIdFilm(id);
            //return items;
            foreach (var film in query)
            {
                foreach(var act in film.Actors)
                {
                    lightActors.Add(new LightActorDTO(act.ActorId, act.Name, act.Surname));
                }
                foreach (var typ in film.FilmTypelist)
                {
                    filmTypes.Add(new FilmTypeDTO(typ.Id, typ.Name));
                }
                foreach (var cmt in film.Comments)
                {
                    comments.Add(new CommentDTO(cmt.Id, cmt.Content, cmt.Rate, cmt.IdFilm, cmt.Username, cmt.DateCom));
                }
                full.Add(new FullFilmDTO(film.FilmId, film.Title, film.Release_Date, film.Vote_Average, film.Runtime, film.Posterpath, comments, filmTypes,lightActors));
            }

            // Get's No of Rows Count   
            return full; //return les infos completes d'un film + des infos complementaires
        }

        public List<FullFilmDTO> GetAllFilms()
        {

            List<FullFilmDTO> full = new List<FullFilmDTO>();
            List<LightActorDTO> lightActors = new List<LightActorDTO>();
            List<FilmTypeDTO> filmTypes = new List<FilmTypeDTO>();
            List<CommentDTO> comments = new List<CommentDTO>();
            //var query = from b in CC.Films.Include(a => a.Actors).Include(c => c.FilmTypelist).Include(e => e.Comments)//AJOUTER SYSTEM.LINQ
            //            where b.FilmId == id
            //            select b;
            //Methode d'acces au DbContext doit etre dans la DAL
            //Faire query.SKIP pour la pagination
            var query = access.GetAllFilms();
            //return items;
            foreach (var film in query)
            {
               // foreach (var act in film.Actors)
               //{
               //     lightActors.Add(new LightActorDTO(act.ActorId, act.Name, act.Surname));
               // }
                foreach (var typ in film.FilmTypelist)
                {
                    filmTypes.Add(new FilmTypeDTO(typ.Id, typ.Name));
                }
                foreach (var cmt in film.Comments)
                {
                    comments.Add(new CommentDTO(cmt.Id, cmt.Content, cmt.Rate, cmt.IdFilm, cmt.Username, cmt.DateCom));
                }
                full.Add(new FullFilmDTO(film.FilmId, film.Title, film.Release_Date, film.Vote_Average, film.Runtime, film.Posterpath, comments, filmTypes, lightActors));
            }
            // Get's No of Rows Count   
            return full; //return les infos completes d'un film + des infos complementaires
        }
        public FullFilmDTO GetFilmByTitle(string title)
        {
            List<FullFilmDTO> full = new List<FullFilmDTO>();
            FullFilmDTO FILM = new FullFilmDTO();
            List<LightActorDTO> lightActors = new List<LightActorDTO>();
            List<FilmTypeDTO> filmTypes = new List<FilmTypeDTO>();
            List<CommentDTO> comments = new List<CommentDTO>();
            //var query = from b in CC.Films.Include(a => a.Actors).Include(c => c.FilmTypelist).Include(e => e.Comments)//AJOUTER SYSTEM.LINQ
            //            where b.FilmId == id
            //            select b;
            //Methode d'acces au DbContext doit etre dans la DAL
            //Faire query.SKIP pour la pagination
            var query = access.GetFullFilmByTitle(title);
            //return items;
            foreach (var film in query)
            {
                foreach (var typ in film.FilmTypelist)
                {
                    filmTypes.Add(new FilmTypeDTO(typ.Id, typ.Name));
                }
                foreach (var cmt in film.Comments)
                {
                    comments.Add(new CommentDTO(cmt.Id, cmt.Content, cmt.Rate, cmt.IdFilm, cmt.Username, cmt.DateCom));
                }
                FILM = new FullFilmDTO(film.FilmId, film.Title, film.Release_Date, film.Vote_Average, film.Runtime, film.Posterpath, comments, filmTypes, lightActors);
            }

            // Get's No of Rows Count   
            return FILM; //return les infos completes d'un film + des infos complementaires
        }
    }
}
