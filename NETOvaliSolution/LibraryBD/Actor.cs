using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryBD
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id;
        public string Name;
        public string Surname;
    }
}
