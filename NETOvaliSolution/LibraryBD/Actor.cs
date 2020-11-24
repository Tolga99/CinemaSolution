using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryBD
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        private int id;
        private string name;
        private string surname;
        private ICollection<Film> films; 
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        //public virtual ICollection<Film> Films get => films; set => films = value; }
        public virtual List<Film> Films { get; set; }
        public Actor()
        {
            Films = new List<Film>();
        }
        public Actor(int ID, string nom, string surnom)
        {
            id = ID;
            name = nom;
            surname = surnom;
        }
        public Actor(string text) // Constructeur d’objet Actor
        {
            string[] acteurdetail, characterdetail;
            string tmp;
            Char[] delimiterChars = { '\u2024' };
            acteurdetail = text.Split(delimiterChars);
            Id = Int32.Parse(acteurdetail[0]);
            Name = acteurdetail[1];
            delimiterChars[0] = '/';
            tmp = acteurdetail[2];
            characterdetail = tmp.Split(delimiterChars);
            Surname = characterdetail[0];
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Actor :");
            sb.AppendLine("ID :" + " " + this.Id + " " + "Name :" + " " + this.Name + " " + "Surname :" + " " + this.Surname);
            return sb.ToString();
        }
        public bool Equals(ICollection<Actor> list)
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
