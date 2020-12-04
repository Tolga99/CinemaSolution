using LibraryBD;
using System;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LibraryDTO;
using LibraryBLL;

namespace ConsoleFilm
{
    public class Program
    {
        static void Main(string[] args)
        {
            CinemaContext cinemaContext;
            DbContextOptionsBuilder<CinemaContext> optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\t_olg\\Desktop\\Ecole\\Bloc 2-3 (2020-2021)\\Q1\\DotNet\\NETOvali\\Cinema.db ;Cache=Shared");

            cinemaContext = new CinemaContext(optionsBuilder.Options);
            //cinemaContext.Database.EnsureDeleted();
            //cinemaContext.Database.EnsureCreated();

            //CreationDBMovie(optionsBuilder);
            #region TEST ACTORS
            ActorsDatabaseMethods act = new ActorsDatabaseMethods(cinemaContext);
            List<LightActorDTO>l= act.GetListActorsByIdFilm(13); //OK 
            List<ActorDTO>ac=act.GetFavoriteActors(); // PAS OK ret=0

            #endregion
            #region TEST FILMS
            FilmsDatabaseMethods flm = new FilmsDatabaseMethods(cinemaContext);
            List<FilmDTO>list=flm.FindListFilmByPartialActorName("Hanks"); //OK
            FullFilmDTO ll=flm.GetFullFilmDetailsByIdFilm(6);//OK

            #endregion

            #region TEST ACTORS
            FilmTypesDatabaseMethods fty = new FilmTypesDatabaseMethods(cinemaContext);
            List<FilmTypeDTO>lll =fty.GetListFilmTypesByIdFilm(6); //OK

            #endregion

            #region TEST Comments
            CommentsDatabaseMethods cmt = new CommentsDatabaseMethods(cinemaContext);
            cmt.InsertCommentOnFilmId(13,"Tres bon film",5,"Tolga");
            #endregion
        }
        private void update(CinemaContext cinemaContext)
        {
            var film = cinemaContext.Films.Find(4);
            film.Title = "Title EOV";

            cinemaContext.SaveChanges();
        }

        private void insert(CinemaContext cinemaContext)
        {
            var film = cinemaContext.Films;
            //film.Title = "Title EOV";

            cinemaContext.SaveChanges();
        }
        public static void CreationDBMovie(DbContextOptionsBuilder options)
        {
            CinemaContext cdb = new CinemaContext(options.Options);
            string movie_file_path = @"C:\Users\t_olg\Desktop\Ecole\Bloc 2-3 (2020-2021)\Q1\movies.txt";
            var F = new StreamReader(movie_file_path);
            string Line = "";
            int i = 0;

            List<Film> ListFilm = new List<Film>();
            while ((Line = F.ReadLine()) != null && i < 1010)
            {
                if (Line == null)
                    return;

                // Creation d'un objet film
                FilmParser filmtext = new FilmParser(cdb);
                Console.WriteLine("La ligne = " + Line);
                Film film = filmtext.DecodeFilmText(Line); //un film a la fois 
                i++;
                cdb.Films.Add(film);
                cdb.SaveChanges();
            }


            F.Close();
        }
    }
}
