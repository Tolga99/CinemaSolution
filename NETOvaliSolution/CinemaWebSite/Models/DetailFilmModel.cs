using LibraryDTO;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebSite.Models
{
    public class DetailFilmModel : HomeFilmModel
    {
        private ICollection<LightActorDTO> actors;
        private ICollection<FilmTypeDTO> filmTypelist;
        private ICollection<CommentDTO> comments;


        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual ICollection<LightActorDTO> Actors { get; set; }
        public ICollection<FilmTypeDTO> FilmTypelist { get => filmTypelist; set => filmTypelist = value; }
        public ICollection<CommentDTO> Comments { get => comments; set => comments = value; }

        public DetailFilmModel() : base()
        {
            Actors = new HashSet<LightActorDTO>();
            FilmTypelist = new HashSet<FilmTypeDTO>();
            Comments = new HashSet<CommentDTO>();
        }
        public DetailFilmModel(ICollection<FilmTypeDTO> type, ICollection<LightActorDTO> act, ICollection<CommentDTO> cmt)
        {
            Actors = act;
            FilmTypelist = type;
            Comments = cmt;
        }
        public DetailFilmModel(int ID, string title, double VoteA, double run, string path, int page) : base(ID, path, title, run, VoteA, page)
        {

        }
        //public FullFilmDTO(int ID, string title, DateTime dates, double VoteA, double run, string path, ICollection<Comment> cmt,ICollection<FilmType> type, ICollection<Actor> act)
        //        : base(ID, title, dates, VoteA, run, path,cmt)
        //{
        //    Actors = act;
        //    FilmTypelist = type;
        //}
        public DetailFilmModel(int ID, string title, double VoteA, double run, string path, int page, ICollection<CommentDTO> cmt, ICollection<FilmTypeDTO> type, ICollection<LightActorDTO> act)
        : base(ID, path, title, run, VoteA, page)
        {
            Actors = act;
            FilmTypelist = type;
            Comments = cmt;
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
            return sb.ToString();
        }
    }
}
