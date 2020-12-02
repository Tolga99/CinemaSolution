using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LibraryBD
{
    public class Actor
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        private string name;
        private string surname;
        private ICollection<Film> films; 
        public int ActorId { get; set; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        //public virtual ICollection<Film> Films get => films; set => films = value; }
        public virtual ICollection<Film> Films { get; set; }
        public Actor()
        {
            Films = new HashSet<Film>();
        }
        public Actor(int ActorId, string nom, string surnom)
        {
            ActorId = ActorId;
            name = nom;
            surname = surnom;
        }
        public Actor(string text) // Constructeur d’objet Actor
        {
            string[] acteurdetail, characterdetail;
            string tmp;
            Char[] delimiterChars = { '\u2024' };
            acteurdetail = text.Split(delimiterChars);
            ActorId = Int32.Parse(acteurdetail[0]);
            char[] spearator = { ' ', ' ' };
            Int32 count = 2;

            // Using the Method 
            String[] strlist = acteurdetail[1].Split(spearator,count, StringSplitOptions.None);
            if(strlist.Length==1)
            {
                Name = "";
            }
            else Name = strlist[1];
            delimiterChars[0] = '/';
            tmp = acteurdetail[2];
            characterdetail = tmp.Split(delimiterChars);
            Surname = strlist[0];
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Actor :");
            sb.AppendLine("ID :" + " " + this.ActorId + " " + "Name :" + " " + this.Name + " " + "Surname :" + " " + this.Surname);
            return sb.ToString();
        }
        public bool Equals(ICollection<Actor> list) //Verifie si cet acteur est contenu dans la liste en parametre
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
                    if (a.ActorId == this.ActorId)
                        return true;
                }
                return false;
            //}
        }
        public List<Actor> Equals(int FilmId)
        {
            List < Actor > list= new List<Actor>();
            foreach (var a in this.films)
            {
                if (a.FilmId == FilmId)
                    list.Add(this);
            }
            return list;
        }
    }
}
