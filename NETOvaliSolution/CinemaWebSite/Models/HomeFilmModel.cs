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
        private int vote_count;
        //private string genres;
        public string Title { get => title; set => title = value; }
        public string Runtime { get => runtime; set => runtime = value; }
        public string Pic { get => pic; set => pic = value; }
        // public string Genres { get => genres; set => genres = value; }
        public int Id { get => id; set => id = value; }
        public int Vote_count { get => vote_count; set => vote_count = value; }
        public double Vote_aver { get => vote_aver; set => vote_aver = value; }

        public HomeFilmModel(int ide, string img, string titre, double temps, double votea, int votec)
        {
            Id = ide;
            Pic = "http://image.tmdb.org/t/p/w185" + img;
            Title = titre;
            Runtime = RuntimeConvert(temps);
            Vote_aver = votea;
            Vote_count = votec;
        }
        public String RuntimeConvert(double run)
        {
            String Temps;
            int nbHour = (int)(run / 60);
            int nbMin = (int)(run - (60 * nbHour));
            return nbHour.ToString() + "h" + nbMin.ToString() + "m";

        }
    }

}