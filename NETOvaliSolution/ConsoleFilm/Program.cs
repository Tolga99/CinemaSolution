using LibraryBD;
using System;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

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
            cinemaContext.Database.EnsureDeleted();
            cinemaContext.Database.EnsureCreated();

            CreationDBMovie(optionsBuilder);

            
            using (var db = new CinemaContext(optionsBuilder.Options))
            {
                var query = from b in db.Films
                            where b.Title == "Star Wars"
                            select b;
                foreach (var item in query)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

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
