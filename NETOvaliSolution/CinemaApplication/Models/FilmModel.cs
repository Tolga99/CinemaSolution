﻿using LibraryDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CinemaApplication.Model
{
    public class FilmModel
    {
        private string pic;
        private string title;
        private string runtime;
        private List<FilmTypeDTO> genres;
        //public string Image { get => Image1; set => Image1 = value; }
        public string Title { get => title; set => title = value; }
        public string Runtime { get => runtime; set => runtime = value; }
        public List<FilmTypeDTO> Genres { get => genres; set => genres = value; }
        public string Pic { get => pic; set => pic = value; }

        public FilmModel(string img, string titre,double temps,List<FilmTypeDTO> list)
        {
            
            //pic.Width = 50;
            //pic.Height = 50;

            // Create a BitmapSource  
            /* BitmapImage bitmap = new BitmapImage();
             bitmap.BeginInit();
             bitmap.UriSource = new Uri(img);
             bitmap.EndInit();
            */
            // Set Image.Source  
            //ImageClub.Source = bitmap;
            Pic = "http://image.tmdb.org/t/p/w185"+img;
            Title = titre;
            Runtime = RuntimeConvert(temps);
            //Genres = list;
        }
        public String RuntimeConvert(double run)
        {
            String Temps;
            int nbHour = (int)(run / 60);
            int nbMin = (int)(run - (60 * nbHour));
            return nbHour.ToString() + "h" + nbMin.ToString() + "m";

        }
    }
}