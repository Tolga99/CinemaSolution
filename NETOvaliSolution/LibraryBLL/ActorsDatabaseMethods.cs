using ConsoleFilm;
using LibraryDTO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

 namespace LibraryBLL
{
    public class ActorsDatabaseMethods
    {
        private CinemaContext CC;

        public ActorsDatabaseMethods()
        {

        }
        public ActorsDatabaseMethods(CinemaContext cc)
        {
            CC = cc;
        }
        /*
        public ActorDTO SelectById(int ActorId)
        {

        }

        public List<ActorDTO> SelectAll()
        {

        }

        public ActorDTO Update(ActorDTO actor)
        {
            var film = cinemaContext.Actor.Find(actor.Id);

            film.Title = actor.Title;

            cinemaContext.SaveChanges();

            return film;
        }

        public ActorDTO Insert(ActorDTO actor)
        {

        }

        public bool Delete(int ActorId)
        {

        }
        */
        public List<ActorDTO> GetFavoriteActors()
        {
            List<ActorDTO> list = new List<ActorDTO>();
            var query = from b in CC.Actors.Include(a => a.Films)//AJOUTER SYSTEM.LINQ
                        where b.Films.Count > 2
                        select b;

            foreach (var actor in query)
            {
                list.Add(new ActorDTO(actor.ActorId, actor.Name, actor.Surname,actor.Films.Count));
            }

            return list; //retourne les acteursdto ayant jouer dans plus de 2 films
        }
        public List<LightActorDTO> GetListActorsByIdFilm(int ID)
        {
            List<LightActorDTO> light = new List<LightActorDTO>();
            var query = from b in CC.Films.Include(a => a.Actors)//AJOUTER SYSTEM.LINQ
                        where b.FilmId == ID
                        select b;

            foreach (var film in query)
            {
                foreach (var actor in film.Actors)
                    light.Add(new LightActorDTO(actor.ActorId, actor.Name, actor.Surname));
            }

            return light;

        }
    }

    }
