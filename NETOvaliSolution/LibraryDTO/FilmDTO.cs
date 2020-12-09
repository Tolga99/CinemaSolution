using LibraryBD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryDTO
{
    public class FilmDTO
    {
        private int id;

        public string ReadLine()
        {
            throw new NotImplementedException();
        }

        private string title;
        private DateTime release_Date;
        private double vote_Average;
        private double runtime;
        private string posterpath;

        private ICollection<Comment> comments;
        //Collection comment
        public string Title { get => title; set => title = value; }
        public DateTime Release_Date { get => release_Date; set => release_Date = value; }
        public double Vote_Average { get => vote_Average; set => vote_Average = value; }
        public double Runtime { get => runtime; set => runtime = value; }
        public string Posterpath { get => posterpath; set => posterpath = value; }
        public int Id { get => id; set => id = value; }
        public virtual ICollection<Comment> Comments { get => comments; set => comments = value; }

        public FilmDTO()
        {

        }
        public FilmDTO(int ID, string title, DateTime dates, double VoteA, double run, string path,ICollection<Comment>cmt)
        {
            Id = ID;
            Title = title;
            Release_Date = dates;
            Vote_Average = VoteA;
            Runtime = run;
            Posterpath = path;
            Comments = cmt;

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Film :");
            sb.AppendLine("Title :" + Title + " " + "Date :" + " " + Release_Date + " " + "Vote Average :" + " " + vote_Average + " " + "Runtime :" + " " + Runtime + " " + "Posterpath :" + " " + Posterpath + " ");
            foreach (Comment data in Comments)
            {
                sb.AppendLine("Commentaires :" + data.ToString());
            }
            return sb.ToString();

        }
    }
}
