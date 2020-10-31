using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace LibraryBD
{
    public class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id;
        public string Title;
        public DateTime Release_Date;
        public double Vote_Average;
        public double Runtime;
        public string Posterpath;

        public List<Actor> Actors;
    }
}
