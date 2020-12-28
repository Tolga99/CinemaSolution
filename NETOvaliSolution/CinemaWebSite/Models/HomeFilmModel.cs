using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebSite.Models
{
    public class HomeFilmModel
    {
        private int id;
        private string pic;
        private string title;
        private string runtime;
        private double vote_aver;
        private int page;
        //private string genres;
        public string Title { get => title; set => title = value; }
        public string Runtime { get => runtime; set => runtime = value; }
        public string Pic { get => pic; set => pic = value; }
        // public string Genres { get => genres; set => genres = value; }
        public int Id { get => id; set => id = value; }
        public double Vote_aver { get => vote_aver; set => vote_aver = value; }
        public int Page { get => page; set => page = value; }

        public HomeFilmModel(int ide, string img, string titre, double temps, double votea,int pg)
        {
            Id = ide;
            Pic = "http://image.tmdb.org/t/p/w185" + img;
            Title = titre;
            Runtime = RuntimeConvert(temps);
            Vote_aver = votea;
            Page = pg;
        }
        public String RuntimeConvert(double run)
        {
            int nbHour = (int)(run / 60);
            int nbMin = (int)(run - (60 * nbHour));
            return nbHour.ToString() + "h" + nbMin.ToString() + "m";

        }
    }

}