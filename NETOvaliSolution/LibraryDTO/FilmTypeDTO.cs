using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDTO
{
    public class FilmTypeDTO
    {
        private int id;
        private string name;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public FilmTypeDTO()
        {

        }
        public FilmTypeDTO(int ID, string nom)
        {
            Id = ID;
            Name = nom;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Genre :");
            sb.AppendLine("ID :" + " " + this.Id + " " + "Genre :" + " " + this.Name);
            return sb.ToString();
        }
    }
}
