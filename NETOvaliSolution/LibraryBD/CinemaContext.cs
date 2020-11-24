using LibraryBD;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleFilm
{
    public class CinemaContext : DbContext
    {
        private StreamReader f;
        private string line;

        public CinemaContext(DbContextOptions options) : base(options)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<CinemaContext>());

        }

        public DbSet<Film> Films
        {
            get;
            set;
        }
        public DbSet<Actor> Actors
        {
            get;
            set;
        }
        public DbSet<Comment> Comments
        {
            get;
            set;
        }
        public DbSet<FilmType> FilmTypes
        {
            get;
            set;
        }
        public string Line { get => line; set => line = value; }
        public StreamReader F { get => f; set => f = value; }

    }
}
