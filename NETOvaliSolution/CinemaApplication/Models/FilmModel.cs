using LibraryDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CinemaApplication.Model
{
    public class FilmModel
    {
        private int id;
        private string pic;
        private string title;
        private string runtime;
        private string genres;
        private ICollection<CommentDTO> comments;
        public string Title { get => title; set => title = value; }
        public string Runtime { get => runtime; set => runtime = value; }
        public string Pic { get => pic; set => pic = value; }
        public ICollection<CommentDTO> Comments { get => comments; set => comments = value; }
        public string Genres { get => genres; set => genres = value; }
        public int Id { get => id; set => id = value; }

        public FilmModel(int ide,string img, string titre,double temps,string genre, ICollection<CommentDTO>cmt)
        {
            Id = ide;
            Pic = "http://image.tmdb.org/t/p/w185"+img;
            Title = titre;
            Runtime = RuntimeConvert(temps);
            Comments = cmt;
            Genres = genre;
        }
        public String RuntimeConvert(double run)
        {
            int nbHour = (int)(run / 60);
            int nbMin = (int)(run - (60 * nbHour));
            return nbHour.ToString() + "h" + nbMin.ToString() + "m";

        }
    }
}
