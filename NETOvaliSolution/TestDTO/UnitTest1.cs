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
        private CinemaContext cinemaContext;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<CinemaContext> optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\t_olg\\Desktop\\Ecole\\Bloc 2-3 (2020-2021)\\Q1\\DotNet\\NETOvali\\Cinema.db ;Cache=Shared");

            cinemaContext = new CinemaContext(optionsBuilder.Options);
        }

        [Test]
        public void Test1()
        {
            ActorsDatabaseMethods act = new ActorsDatabaseMethods();
            act.GetListActorsByIdFilm(1);
        }
    }
}