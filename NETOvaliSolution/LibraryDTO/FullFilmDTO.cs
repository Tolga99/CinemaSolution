using LibraryBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDTO
{
    public class FullFilmDTO : FilmDTO
    {

        private ICollection<Actor> actors;
        private ICollection<FilmType> filmTypelist;

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<FilmType> FilmTypelist { get => filmTypelist; set => filmTypelist = value; }
        public FullFilmDTO() : base()
        {
            Actors = new HashSet<Actor>();
            FilmTypelist = new HashSet<FilmType>();
        }
        public FullFilmDTO(ICollection<FilmType> type, ICollection<Actor> act)
        {
            Actors = act;
            FilmTypelist = type;
        }
        public FullFilmDTO(int ID, string title, DateTime dates, double VoteA, double run, string path, ICollection<Comment> cmt) : base(ID,title,dates,VoteA,run,path,cmt)
        {

        }
        public FullFilmDTO(int ID, string title, DateTime dates, double VoteA, double run, string path, ICollection<Comment> cmt,ICollection<FilmType> type, ICollection<Actor> act)
                : base(ID, title, dates, VoteA, run, path,cmt)
        {
            Actors = act;
            FilmTypelist = type;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("Film :");
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