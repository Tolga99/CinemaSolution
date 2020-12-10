using ConsoleFilm;
using LibraryDTO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryBD;

namespace LibraryBLL
{
    public class CommentsDatabaseMethods
    {
        public AccessMethods access;
        public CommentsDatabaseMethods()
        {
            access = new AccessMethods();

        }

        public void InsertCommentOnFilmId(int idfilm,string contenu, int note,string user)
        {
            //var film = CC.Films.Find(id);
            //int Comid=FindLastId();
            var query= access.GetFilmWActorsById(idfilm);
            Film film = null;
            foreach(var fl in query)
            {
                film = new Film(fl.FilmId, fl.Title, fl.Release_Date, fl.Vote_Average, fl.Runtime, fl.Posterpath,fl.FilmTypelist,fl.Actors,fl.Comments);
            }
            int Comid=access.FindLastId();
            CommentDTO comment = new CommentDTO(Comid,contenu, note, idfilm, user, System.DateTime.UtcNow);
            Comment cmt = new Comment(comment.Id,comment.Content, comment.Rate, comment.IdFilm, comment.Username, comment.DateCom);
            access.AddComment(film, cmt);
            //CC.Comments.Add(cmt);
            //film.Comments.Add(cmt);
            //CC.SaveChanges();
        }
    }
}
