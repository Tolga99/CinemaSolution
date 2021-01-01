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
            var query = access.GetAllActors();
            foreach (var actor in query)
            {
                if (actor.Name == name)
                {
                    foreach (var film in actor.Films)
                        list.Add(new FilmDTO(film.FilmId, film.Title, film.Release_Date, film.Vote_Average, film.Runtime, film.Posterpath, film.Comments));
                }
            }
            return list;
        }
        public List<FilmDTO> FindListFilmByFullActorName(string name,string surname)
        {
            List<FilmDTO> list = new List<FilmDTO>();
            var query = access.GetAllActors();
            foreach (var actor in query)
            {

                if (actor.Name == name && actor.Surname == surname)
                {
                    foreach (var film in actor.Films)
                        list.Add(new FilmDTO(film.FilmId, film.Title, film.Release_Date, film.Vote_Average, film.Runtime, film.Posterpath, film.Comments));
                }
            }
            return list;
        }
        public FilmDTO FindFilmWComById(int ID)
        {
            FilmDTO flm = null ;

            var query = access.GetFilmWComById(ID);
            foreach (var film in query)
                flm= new FilmDTO(film.FilmId, film.Title, film.Release_Date, film.Vote_Average, film.Runtime, film.Posterpath, film.Comments);
            return flm;
        }
        public List<FullFilmDTO> GetFullFilmDetailsByIdFilm(int id)
        {

            List<FullFilmDTO> full=new List<FullFilmDTO>();
            List<LightActorDTO> lightActors = new List<LightActorDTO>();
            List<FilmTypeDTO> filmTypes = new List<FilmTypeDTO>();
            List<CommentDTO> comments = new List<CommentDTO>();
            var query = access.GetFullFilmByIdFilm(id);
            //return items;
            foreach (var film in query)
            {
                filmTypes.Clear();
                comments.Clear();
                lightActors.Clear();
                foreach (var act in film.Actors)
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
            return full; 
        }

        public List<FullFilmDTO> GetAllFilms()
        {

            List<FullFilmDTO> full = new List<FullFilmDTO>();
            List<LightActorDTO> lightActors = new List<LightActorDTO>();
            var query = access.GetAllFilms();
            //return items;
            foreach (var film in query)
            {
                List<FilmTypeDTO> filmTypes = new List<FilmTypeDTO>();
                List<CommentDTO> comments = new List<CommentDTO>();
                foreach (var typ in film.FilmTypelist)
                {
                    filmTypes.Add(new FilmTypeDTO(typ.Id, typ.Name));
                }
                foreach (var cmt in film.Comments)
                {
                    comments.Add(new CommentDTO(cmt.Id, cmt.Content, cmt.Rate, cmt.IdFilm, cmt.Username, cmt.DateCom));
                }
                full.Add(new FullFilmDTO(film.FilmId, film.Title, film.Release_Date, film.Vote_Average, film.Runtime, film.Posterpath,comments, filmTypes, lightActors));
            }
            return full;
        }
        public FullFilmDTO GetFilmByTitle(string title)
        {
            List<FullFilmDTO> full = new List<FullFilmDTO>();
            FullFilmDTO FILM = new FullFilmDTO();
            List<LightActorDTO> lightActors = new List<LightActorDTO>();
            var query = access.GetFullFilmByTitle(title);
            foreach (var film in query)
            {
                List<FilmTypeDTO> filmTypes = new List<FilmTypeDTO>();
                List<CommentDTO> comments = new List<CommentDTO>();
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

            return FILM;
        }
    }
}
