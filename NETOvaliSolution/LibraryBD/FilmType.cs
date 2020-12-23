using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    public class FilmType
    {
        private int id;
        private string name;
        private ICollection<Film> films;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public virtual ICollection<Film> Films { get; set; }

        public FilmType()
        {

        }
        public FilmType(int ID, string nom)
        {
            Id = ID;
            Name = nom;
        }
        public FilmType(string text) // Constructeur de FilmType (type de film)
        {
            string[] genredetail;
            Char[] delimiterChars = { '\u2024' };
            genredetail = text.Split(delimiterChars);
            Id = Int32.Parse(genredetail[0]);
            Name = genredetail[1];
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Genre :");
            sb.AppendLine("ID :" + " " + this.Id + " " + "Genre :" + " " + this.Name);
            return sb.ToString();
        }
        public List<FilmType> Equals(int FilmId)
        {
            List<FilmType> list = new List<FilmType>();
            foreach (var a in this.films)
            {
                if (a.FilmId == FilmId)
                    list.Add(this);
            }
            return list;
        }
        public bool Equals(ICollection<FilmType> list) //Verifie si cet acteur est contenu dans la liste en parametre
        {
            //Check for null and compare run-time types.
            //if ((this == null) || !this.GetType().Equals(this.GetType()))
            //{
            //   return false;
            //}
            //else
            //if
            //{
            foreach (var a in list)
            {
                if (a.Id == this.Id)
                    return true;
            }
            return false;
            //}
        }
    }
}
