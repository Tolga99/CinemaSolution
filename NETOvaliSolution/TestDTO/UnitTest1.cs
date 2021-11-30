using ConsoleFilm;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.DependencyInjection;
using LibraryDTO;
using LibraryBLL;

namespace TestDTO
{
    public class Tests
    {
        private ActorsDatabaseMethods act;
        [SetUp]
        public void Setup()
        {
            act = new ActorsDatabaseMethods();
        }

        [Test]
        public void TestActorsbyIdFilm()
        {
            List<LightActorDTO> l = act.GetListActorsByIdFilm(13); //OK 
            foreach(var a in l)
                Console.WriteLine(a);

        }
        [Test]
        public void TestActorsFavorite()
        {
            List<ActorDTO> ac = act.GetFavoriteActors(); // PAS OK ret=0
            foreach(var a in ac)
                Console.WriteLine(a.ToString());

        }
        [Test]
        public void TestFilmsbyName()
        {
            FilmsDatabaseMethods flm = new FilmsDatabaseMethods();
            List<FilmDTO> list = flm.FindListFilmByPartialActorName("Hanks"); //OK
            foreach (var a in list)
                Console.WriteLine(a);
        }

        [Test]
        public void TestListFilmTypesByIdFilm()
        {
            FilmTypesDatabaseMethods fty = new FilmTypesDatabaseMethods();
            List<FilmTypeDTO> lll = fty.GetListFilmTypesByIdFilm(6); //OK
            foreach (var a in lll)
                Console.WriteLine(a);
        }
        [Test]
        public void TestInsertCom()
        {
            CommentsDatabaseMethods cmt = new CommentsDatabaseMethods();
            cmt.InsertCommentOnFilmId(13, "Tres bon film", 5, "Tolga");

        }
    }
}