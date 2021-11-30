using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace LibraryDTO
{
    public class LightActorDTO
    {
    private int id;
    private string name;
    private string surname;
    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Surname { get => surname; set => surname = value; }
    public LightActorDTO()
    {

    }
    public LightActorDTO(int ID, string nom, string surnom)
    {
        id = ID;
        name = nom;
        surname = surnom;
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