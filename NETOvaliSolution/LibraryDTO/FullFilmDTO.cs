using LibraryBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDTO
{
    public class FullFilmDTO : FilmDTO
    {

        private ICollection<LightActorDTO> actors;
        private ICollection<FilmTypeDTO> filmTypelist;

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual ICollection<LightActorDTO> Actors { get; set; }
        public ICollection<FilmTypeDTO> FilmTypelist { get => filmTypelist; set => filmTypelist = value; }
        public FullFilmDTO() : base()
        {
            Actors = new HashSet<LightActorDTO>();
            FilmTypelist = new HashSet<FilmTypeDTO>();
        }
        public FullFilmDTO(ICollection<FilmTypeDTO> type, ICollection<LightActorDTO> act)
        {
            Actors = act;
            FilmTypelist = type;
        }
        public FullFilmDTO(int ID, string title, DateTime dates, double VoteA, double run, string path, ICollection<CommentDTO> cmt) : base(ID,title,dates,VoteA,run,path,cmt)
        {

        }
        //public FullFilmDTO(int ID, string title, DateTime dates, double VoteA, double run, string path, ICollection<Comment> cmt,ICollection<FilmType> type, ICollection<Actor> act)
        //        : base(ID, title, dates, VoteA, run, path,cmt)
        //{
        //    Actors = act;
        //    FilmTypelist = type;
        //}
        public FullFilmDTO(int ID, string title, DateTime dates, double VoteA, double run, string path, ICollection<CommentDTO> cmt, ICollection<FilmTypeDTO> type, ICollection<LightActorDTO> act)
        : base(ID, title, dates, VoteA, run, path, cmt)
        {
            Actors = act;
            FilmTypelist = type;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("Film :");
            foreach (FilmTypeDTO data in filmTypelist)
            {
                sb.AppendLine("Genres :" + data.ToString());
            }
            foreach (LightActorDTO data in actors)
            {
                sb.AppendLine("Actors :" + data.ToString());
            }
            return base.ToString()+sb.ToString();
        }
    }
}