using CinemaApplication.Model;
using CinemaApplication.Services;
using LibraryDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CinemaApplication.ViewModel
{
    public class FilmViewModel : INotifyPropertyChanged
    {
        int i = 0;
        public ObservableCollection<FilmModel> Films { get; set; }
        public ICommand cmdClick { get; set; }
        public ICommand cmdSearch { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        String rech;
        protected void OnPropertyChanged([CallerMemberName] string name=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void NextPage()
        {
            Client ac = new Client("http://localhost:53454/swagger/v1/swagger.json", new System.Net.Http.HttpClient());


            using (var httpClient = new HttpClient())
            {
                i++;
                using (var response = await httpClient.GetAsync("http://localhost:53454/api/film/all?page="+i+"&pagesize="+5))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var f = JsonConvert.DeserializeObject<List<LibraryDTO.FullFilmDTO>>(apiResponse);
                    Films.Clear();
                    foreach (var ff in f)
                    {
                        Films.Add(new FilmModel(ff.Posterpath,ff.Title,ff.Runtime,null));
                    }
                }
            }
        }
        private async void Search()
        {
            Client ac = new Client("http://localhost:53454/swagger/v1/swagger.json", new System.Net.Http.HttpClient());
            
            
            using (var httpClient = new HttpClient())
            {
                i++;
                using (var response = await httpClient.GetAsync("http://localhost:53454/api/film/name"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                  /*  var f = JsonConvert.DeserializeObject<List<LibraryDTO.FullFilmDTO>>(apiResponse);
                    Films.Clear();
                    foreach (var ff in f)
                    {
                        Films.Add(new FilmModel(ff.Posterpath, ff.Title, ff.Runtime, null));
                    }*/
                }
            }
        }

        public FilmViewModel()
        {
            cmdClick = new DelegateCommand((a) => NextPage());
            cmdSearch = new DelegateCommand((a) => Search());
            Films = new ObservableCollection<FilmModel>();
           /* Films.Add(new FilmModel()
            {
                Title = "Film 1",
                Runtime = "2h30"
            });

            Films.Add(new FilmModel
            {
                Title = "Film 2",
                Runtime = "1h30"
            });*/
        }

    }
}
