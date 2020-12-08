using LibraryBD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace LibraryDTO
{
    public class ActorDTO
    {
        private int id;
        private string name;
        private string surname;
        private int nbFilms;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int NbFilms { get => nbFilms; set => nbFilms = value; }

        //public virtual ICollection<Film> Films get => films; set => films = value; }
        public ActorDTO()
        {
        }
        public ActorDTO(int ID, string nom, string surnom,int nb)
        {
            id = ID;
            name = nom;
            surname = surnom;
            NbFilms = nb;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Actor :");
            sb.AppendLine("ID :" + " " + this.Id + " " + "Name :" + " " + this.Name + " " + "Surname :" + " " + this.Surname);
            return sb.ToString();
        }
    }
}
