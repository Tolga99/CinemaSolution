using System;
using System.Text;

namespace CinemaWebSite.Models
{
    public class ActorModel
    {
        private int id;
        private string name;
        private string biography;
        private string profile_path;
        private DateTime birthday;
        private int age;
        private DateTime deathday;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public DateTime Deathday { get => deathday; set => deathday = value; }
        public string Biography { get => biography; set => biography = value; }
        public string Profile_path { get => profile_path; set => profile_path = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }

        public ActorModel()
        {

        }
        public ActorModel(int ID, string nom, string bio, string img, DateTime date, int year)
        {
            id = ID;
            name = nom;
            Biography = bio;
            Profile_path = img;
            Birthday = date;
            age = year;

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Actor :");
            // sb.AppendLine("ID :" + " " + this.Id + " " + "Name :" + " " + this.Name + " " + "Surname :" + " " + this.Surname);
            return sb.ToString();
        }
    }
}
