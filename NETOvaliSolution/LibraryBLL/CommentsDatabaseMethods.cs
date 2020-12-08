﻿using ConsoleFilm;
using LibraryDTO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryBD;

namespace LibraryBLL
{
    public class CommentsDatabaseMethods
    {
        private CinemaContext CC;

        public CommentsDatabaseMethods()
        {
            DbContextOptionsBuilder<CinemaContext> optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\t_olg\\Desktop\\Ecole\\Bloc 2-3 (2020-2021)\\Q1\\DotNet\\NETOvali\\Cinema.db ;Cache=Shared");
            CC = new CinemaContext(optionsBuilder.Options);
        }
        public CommentsDatabaseMethods(CinemaContext cc)
        {
            CC = cc;
        }
        public void AddComment(CommentDTO cdto)
        {
            //CC.
        }
        public void InsertCommentOnFilmId(int id,string contenu, int note,string user)
        {
            var film = CC.Films.Find(id);
            //var film = CC.Actor.Find(actor.Id);
            CommentDTO comment = new CommentDTO(contenu, note, id, user, System.DateTime.UtcNow);
            Comment cmt = new Comment(comment.Content, comment.Rate, comment.IdFilm, comment.Username, comment.DateCom);
            CC.Comments.Add(cmt);
            film.Comments.Add(cmt);
            CC.SaveChanges();
        }
    }
}