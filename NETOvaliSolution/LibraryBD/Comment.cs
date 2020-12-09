using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    public class Comment
    {
        private int id;
        private string content;
        private int rate;
        private int idFilm;
        private string username;
        private DateTime dateCom;
        private static int globalCount;

        public string Content { get => content; set => content = value; }
        public int Rate { get => rate; set => rate = value; }
        public int IdFilm { get => idFilm; set => idFilm = value; }
        public string Username { get => username; set => username = value; }
        public DateTime DateCom { get => dateCom; set => dateCom = value; }
        public int Id { get => id; set => id = value; }
        public static int GlobalCount { get => globalCount; set => globalCount = value; }

        public Comment()
        {

        }
        public Comment(int iden,string contenu, int note, int ID, string user, DateTime dates)
        {
            Id = iden;
            Content = contenu;
            Rate = note;
            IdFilm = ID;
            Username = user;
            DateCom = dates;
        }
    }
}
