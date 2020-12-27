using CinemaApplication.Model;
using CinemaApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CinemaApplication.Views
{
    /// <summary>
    /// Interaction logic for FilmWindow.xaml
    /// </summary>
    public partial class FilmWindow : Window
    {
        public FilmModel filmAct;
        public FilmWindow()
        {
            InitializeComponent();
        }
        public FilmWindow(FilmModel fm)
        {
            InitializeComponent();
           // this.filmAct = fm;
           // CommentViewModel cvm = new CommentViewModel(filmAct);
       
        }
    }
}
