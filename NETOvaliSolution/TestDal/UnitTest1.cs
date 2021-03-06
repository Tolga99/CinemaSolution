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
        private AccessMethods am;
        [SetUp]
        public void Setup()
        {
            am = new AccessMethods();
        }

        [Test]
        public void GetFilmbyId()
        {
            int i = 1;
            int j = 0;
            while(j<5)
            {
                var ff = am.GetFilmWActorsById(i);// am.GetFullFilmByIdFilm(i);
                foreach(Film f in ff)
                {
                    if (f != null)
                    {
                        Console.WriteLine(f);
                        j++;
                    }
                }
                i++;
            }
        }

        [Test]
        public void GetFullFilmByTitle()
        {
            var ff = am.GetFullFilmByTitle("Back To the Future");
            foreach (Film f in ff)
            {
                if (f != null)
                {
                    Console.WriteLine(f);
                }
            }
        }
        [Test]
        public void GetFilmByActorName()
        {
            var query = am.GetAllActors();
            foreach (var actor in query)
            {
                if (actor.Name.ToLower() == "Hanks".ToLower() && actor.Surname.ToLower() == "Tom".ToLower())
                {
                    foreach (Film film in actor.Films)
                            Console.WriteLine(film);
                }
            }
        }

        [Test]
        public void GetFullFilmByTitle2()
        {
            int i = 1;
            int j = 0;
            var ff = am.GetFullFilmByTitle("Mrs DoubtFire");
            foreach (Film f in ff)
            {
                if (f != null)
                {
                    Console.WriteLine(f);
                }
            }
        }
    }
}