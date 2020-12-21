using ConsoleFilm;
using LibraryBD;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace TestDal
{
    public class Tests
    {
        private CinemaContext cinemaContext;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<CinemaContext> optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\t_olg\\Desktop\\Ecole\\Bloc 2-3 (2020-2021)\\Q1\\DotNet\\NETOvali\\Cinema.db ;cache=shared");
            cinemaContext = new CinemaContext(optionsBuilder.Options);
            cinemaContext.Database.EnsureDeleted();
            cinemaContext.Database.EnsureCreated();
        }

        [Test]
        public void Test1()
        {
            DateTime time = new DateTime(1999, 05, 10);
            try
            {
                cinemaContext.AddRange(new FilmType(1, "Comedie"));
                cinemaContext.AddRange(new FilmType(2, "Horreur"));
                cinemaContext.AddRange(new Actor(1, "de Niro", "Robert"));
                cinemaContext.AddRange(new Film(1,"Taxi Driver", time, 12.5, 128, "aa"));
                foreach (FilmType type in cinemaContext.FilmTypes.ToList())
                {
                    Console.WriteLine(type);
                }
                cinemaContext.SaveChanges();
                Assert.Pass();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Test]
        public void Test2()
        {
            DateTime time = new DateTime(1999, 05, 10);
            try
            {
                cinemaContext.SaveChanges();
                Assert.Pass();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void SaveFilmToDataBase(Film film)
        {
            using (var db = cinemaContext)
            {
                db.Films.Add(film);
                db.SaveChanges();
                db.Dispose();
            }
        }
        public void CreationDBMovie()
        {
            CinemaContext cdb = cinemaContext;
            string movie_file_path = @"C:\Users\t_olg\Desktop\Ecole\Bloc 2-3 (2020-2021)\Q1\DotNet\NETOvali\movies.txt";
            var F = new StreamReader(movie_file_path);
            string Line = "";
            int i = 0;

            List<Film> ListFilm = new List<Film>();
            while ((Line = F.ReadLine()) != null && i < 1010)
            {
                if (Line == null)
                    return;

                // Creation d'un objet film
                FilmParser filmtext = new FilmParser();
                Console.WriteLine("La ligne = " + Line);
                Film film = FilmParser.DecodeFilmText(Line); //un film a la fois 
                i++;
                SaveFilmToDataBase(film);
            }


            F.Close();
        }
    }
}