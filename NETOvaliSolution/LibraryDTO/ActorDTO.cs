using LibraryBD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace LibraryDTO
{
    public class ActorDTO : LightActorDTO
    {
        private int nbFilms;

        public int NbFilms { get => nbFilms; set => nbFilms = value; }

        public ActorDTO() : base()
        {
        }
        public ActorDTO(int ID, string nom, string surnom,int nb) : base(ID,nom,surnom)
        {
            NbFilms = nb;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre de films : "+this.nbFilms);
            return base.ToString()+sb.ToString();
        }
    }
}
