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
            f.Id = Int32.Parse(filmdetailwords[0]);
            f.Title = filmdetailwords[1];
            //DATE

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
                            Console.WriteLine("Genre deja existant :" + s);
                        }
                        else
                        if (f.FilmTypelist.Contains(newType)==true)
                        {
                            Console.WriteLine("Genre deja existant : " + s);
                        }
                        else f.FilmTypelist.Add(new FilmType(s));

                    }

                }
                acteurs = filmdetailwords[14].Split(delimiterChars);
                foreach (string s in acteurs)
                    if (s.Length > 0)//ds la bd ? ds le F ?
                    {
                        Actor newActor = new Actor(s);
                        if (VerifIdActor(newActor.Id)!=null)
                        {
                            Console.WriteLine("Acteur deja existant :" + s);
                        }else
                        //if (f.Actors.Contains(newActor)==true)
                        if(newActor.Equals(f.Actors)==true)
                        {
                            Console.WriteLine("Acteur deja existant :" + s);
                        }
                        else f.Actors.Add(new Actor(s));
                    }
            }
            return f;
        }

        public Actor VerifIdActor(int id)
        {
            //var query1 = CC.Actors.Where(a => a.Id == id);
            var query = from b in CC.Actors
                            where b.Id == id
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