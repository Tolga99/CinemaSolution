using LibraryBD;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ConsoleFilm
{
    public class FilmParser
    {
        // <copyright file="FilmParser" company="Haute Ecole de la Province de Liège">
        // Copyright (c) 2016 All Rights Reserved
        // <author>Cécile Moitroux</author>
        // </copyright>
        private CinemaContext CC;
        private static string[] filmdetailwords;
        private static string[] genres;
        private static string[] acteurs;
        public FilmParser(CinemaContext cc)
        {
            CC = cc;            
        }
        public Film DecodeFilmText(string filmtext) // Méthode de la classe FilmParser
        {
            Film f = new Film();
            char[] delimiterChars = { '\u2023' }; // verifier si c’est le bon délimiteur
            filmdetailwords = filmtext.Split(delimiterChars);
            delimiterChars[0] = '\u2016'; // verifier si c’est le bon délimiteur
                                          // Initialisation des champs de base du film
            f.FilmId = Int32.Parse(filmdetailwords[0]);
            f.Title = filmdetailwords[1];
            if(filmdetailwords[3].Equals("")==false)
                f.Release_Date =Convert.ToDateTime(filmdetailwords[3]);

            f.Vote_Average = double.Parse(filmdetailwords[5], CultureInfo.InvariantCulture);
            if (filmdetailwords[7] == "")
                f.Runtime = 0;
            else f.Runtime = Int32.Parse(filmdetailwords[7]); //CHAMP VIDE BUG !
            f.Posterpath = filmdetailwords[9];
            // Initialisation des champs détails du film
            if (filmdetailwords.Length == 15)
            {
                genres = filmdetailwords[12].Split(delimiterChars);
                foreach (string s in genres)
                {
                    if (s.Length > 0)
                    {
                        FilmType newType = new FilmType(s);
                        if (VerifIdFilmType(newType.Id) != null)
                        {
                            Console.WriteLine("Acteur deja existant dans la BD :" + s);
                            var FilmTyp = CC.FilmTypes.Find(newType.Id);
                            FilmTyp.Films.Add(f);
                            //CC.SaveChanges();
                        }
                        else
                        //if (f.Actors.Contains(newActor)==true)
                        if (newType.Equals(f.FilmTypelist) == true)
                        {
                            Console.WriteLine("Acteur deja existant dans le film:" + s);
                        }
                        else f.FilmTypelist.Add(newType);

                    }

                }
                acteurs = filmdetailwords[14].Split(delimiterChars);
                foreach (string s in acteurs)
                    if (s.Length > 0)//ds la bd ? ds le F ?
                    {
                        Actor newActor = new Actor(s);
                        if (VerifIdActor(newActor.ActorId) !=null)
                        {
                            Console.WriteLine("Acteur deja existant dans la BD :" + s);
                            var Actor = CC.Actors.Find(newActor.ActorId);
                            Actor.Films.Add(f);
                            //CC.SaveChanges();
                        }
                        else
                        //if (f.Actors.Contains(newActor)==true)
                        if(newActor.Equals(f.Actors)==true)
                        {
                            Console.WriteLine("Acteur deja existant dans le film:" + s);
                        }
                        else f.Actors.Add(newActor);
                    }
            }
            return f;
        }

        public Actor VerifIdActor(int id)
        {
            //var query1 = CC.Actors.Where(a => a.Id == id);
            var query = from b in CC.Actors
                            where b.ActorId == id
                            select b;
            Console.WriteLine(query.FirstOrDefault());
            return query.FirstOrDefault();
        }
        public FilmType VerifIdFilmType(int id)
        {
            //var query1 = CC.Actors.Where(a => a.Id == id);
            var query = from b in CC.FilmTypes
                        where b.Id == id
                        select b;
            return query.FirstOrDefault();
        }
    }

}