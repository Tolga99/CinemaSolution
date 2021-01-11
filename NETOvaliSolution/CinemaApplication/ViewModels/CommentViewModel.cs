using CinemaApplication.Model;
using CinemaApplication.Services;
using LibraryDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApplication.ViewModels
{
    public class CommentViewModel : INotifyPropertyChanged
    {
        public string contenu { get; set; }
        public double rate { get; set; }
        public string rateAv { get; set; }
        public double moyenne { get; set; }

        public string username { get; set; }
        public FilmModel FilmCom { get; set; }
        public ObservableCollection<LibraryDTO.CommentDTO> Commentaires{ get; set; }

        public ICommand cmdClick { get; set; }
        public ICommand cmdComment { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        //public String rech { get; set; }
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void AddComment()
        {
            Client ac = new Client("http://localhost:53454/swagger/v1/swagger.json", new System.Net.Http.HttpClient());
            var content = new StringContent('"' + contenu + '"', Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync("http://localhost:53454/api/Comment/film/"+FilmCom.Id+"?note="+rate+"&user="+username, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            GetComments();
        }
        public async void GetComments()
        {
            Client ac = new Client("http://localhost:53454/swagger/v1/swagger.json", new System.Net.Http.HttpClient());
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:53454/api/Comment/film/" + FilmCom.Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var com = JsonConvert.DeserializeObject<List<LibraryDTO.CommentDTO>>(apiResponse);
                    Commentaires.Clear();
                    if (com == null)
                    {
                        Console.WriteLine("Commentaires ou film pas trouve");
                    }
                    else
                    {
                        foreach (var c in com)
                        {
                            Commentaires.Add(c);
                            moyenne += c.Rate;
                        }
                        moyenne /= com.Count();
                    }
                }
            }
            rateAv = moyenne.ToString("F2");
            FilmCom.Average = moyenne;
        }
        public CommentViewModel()
        {
            cmdComment = new DelegateCommand((a) => AddComment());
            Commentaires = new ObservableCollection<LibraryDTO.CommentDTO>();
        }
        public CommentViewModel(FilmModel filmModel)
        {
            cmdComment = new DelegateCommand((a) => AddComment());
            this.FilmCom = filmModel;
            Commentaires = new ObservableCollection<LibraryDTO.CommentDTO>();
            GetComments();
        }
    }
}