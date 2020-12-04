using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Reflection.Metadata;
using System.Text;

namespace LibraryBD
{
    public class Film
    {

        public string ReadLine()
        {
            throw new NotImplementedException();
        }

        private string title;
        private DateTime release_Date;
        private double vote_Average;
        private double runtime;
        private string posterpath;

        private ICollection<Actor> actors;
        private ICollection<FilmType> filmTypelist;
        private ICollection<Comment> comments;
        //Collection comment
        public string Title { get => title; set => title = value; }
        public DateTime Release_Date { get => release_Date; set => release_Date = value; }
        public double Vote_Average { get => vote_Average; set => vote_Average = value; }
        public double Runtime { get => runtime; set => runtime = value; }
        public string Posterpath { get => posterpath; set => posterpath = value; }
        //public virtual ICollection<Actor> Actors { get => actors; set => actors = value; }


        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FilmId { get; set; }
        public virtual ICollection<Comment> Comments { get => comments; set => comments = value; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<FilmType> FilmTypelist { get => filmTypelist; set => filmTypelist = value; }
        public Film()
        {
            Actors = new HashSet<Actor>();
            FilmTypelist = new HashSet<FilmType>();
            Comments = new HashSet<Comment>();
        }
        public Film(ICollection<FilmType> type,ICollection<Actor>act,ICollection<Comment>cmt)
        {
            Actors = act;
            FilmTypelist = type;
            Comments = cmt;
        }
        public Film(int ID, string title, DateTime dates, double VoteA, double run, string path)
        {
            FilmId = ID;
            Title = title;
            Release_Date = dates;
            Vote_Average = VoteA;
            Runtime = run;
            Posterpath = path;

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Film :");
            sb.AppendLine("Title :" + Title + " " + "Date :" + " " + Release_Date + " " + "Vote Average :" + " " + vote_Average + " " + "Runtime :" + " " + Runtime + " " + "Posterpath :" + " " + Posterpath + " ");
            foreach (FilmType data in filmTypelist)
            {
                sb.AppendLine("Genres :" + data.ToString());
            }
            foreach (Actor data in actors)
            {
                sb.AppendLine("Actors :" + data.ToString());
            }
            return sb.ToString();

        }
    }
}
