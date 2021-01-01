using CinemaApplication.Model;
using CinemaApplication.Services;
using CinemaApplication.ViewModels;
using CinemaApplication.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace CinemaApplication.ViewModel
{
    public class FilmViewModel : INotifyPropertyChanged
    {
        int i = 0;
        
        public ObservableCollection<FilmModel> Films { get; set; }
        public ICommand cmdClick { get; set; }
        public ICommand cmdSearch { get; set; }
        public ICommand cmdVisu { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public String rech { get; set; }
        public FilmModel Actuel { get; set; }
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
                        Films.Add(new FilmModel(ff.Id,ff.Posterpath,ff.Title,ff.Runtime, GenreImage(ff.FilmTypelist), ff.CommentsD));
                    }
                }
            }
        }
        private async void Search()
        {
            Client ac = new Client("http://localhost:53454/swagger/v1/swagger.json", new System.Net.Http.HttpClient());
            var content = new StringContent('"'+rech+'"', Encoding.UTF8,"application/json");
            using (var httpClient = new HttpClient())
            {
                 using (var response = await httpClient.PostAsync("http://localhost:53454/api/Film/name",content))
                 {
                     string apiResponse = await response.Content.ReadAsStringAsync();
                     var ff = JsonConvert.DeserializeObject<LibraryDTO.FullFilmDTO>(apiResponse);
                     Films.Clear();
                     if(ff==null)
                    {
                        Console.WriteLine("Film pas trouve");
                    }else Films.Add(new FilmModel(ff.Id,ff.Posterpath, ff.Title, ff.Runtime,GenreImage(ff.FilmTypelist),ff.CommentsD));
                 }
            }
        }
        private void Visualise()
        {
            Films.Count();
            Actuel.Title.ToString();
            //CommentViewModel cwm = new CommentViewModel(Actuel);
            FilmWindow fw = new FilmWindow();
            fw.DataContext = new CommentViewModel(Actuel);
            fw.Show();
        }

        public FilmViewModel()
        {
            cmdClick = new DelegateCommand((a) => NextPage());
            cmdSearch = new DelegateCommand((a) => Search());
            cmdVisu = new DelegateCommand((a) => Visualise());
            Films = new ObservableCollection<FilmModel>();
        }
        public string GenreImage(ICollection<LibraryDTO.FilmTypeDTO> list)
        {
            IEnumerator<LibraryDTO.FilmTypeDTO> enume= list.GetEnumerator();
            while (enume.MoveNext() != false)
            {
                if (enume.Current == null)
                {
                    return "https://image.flaticon.com/icons/png/512/36/36601.png";
                }
                else
                {
                    if (enume.Current.Name == "Adventure")
                    {
                        return "https://static.thenounproject.com/png/1034013-200.png";
                    }
                    else if (enume.Current.Name == "Action")
                    {
                        return "https://icon-library.com/images/icon-action/icon-action-9.jpg";
                    }
                    else if (enume.Current.Name == "Animation")
                    {
                        return "https://individual.icons-land.com/IconsPreview/Multimedia/PNG/256x256/FilmGenre_Cartoon.png";
                    }
                    else if (enume.Current.Name == "Drama")
                    {
                        return "https://static.thenounproject.com/png/589710-200.png";
                    }
                    else if (enume.Current.Name == "Horror")
                    {
                        return "https://static.thenounproject.com/png/2972512-200.png";
                    }
                    else if (enume.Current.Name == "Comedy")
                    {
                        return "https://static.thenounproject.com/png/60743-200.png";
                    }
                    else if (enume.Current.Name == "Western")
                    {
                        return "https://image.flaticon.com/icons/png/512/83/83662.png";
                    }
                    else if (enume.Current.Name == "Music")
                    {
                        return "https://cdn3.iconfinder.com/data/icons/music-and-audio-1/26/music-audio-1027-512.png";
                    }
                    else if (enume.Current.Name == "Science Fiction")
                    {
                        return "https://static.thenounproject.com/png/61057-200.png";
                    }
                    else if (enume.Current.Name == "Romance")
                    {
                        return "https://cdn.iconscout.com/icon/premium/png-256-thumb/romance-21-895354.png";
                    }
                    else if (enume.Current.Name == "Documentary")
                    {
                        return "https://cdn.iconscout.com/icon/premium/png-512-thumb/documentary-3-581150.png";
                    }
                    else if (enume.Current.Name == "Thriller")
                    {
                        return "https://image.shutterstock.com/image-vector/thriller-book-icon-outline-vector-260nw-1830363263.jpg";
                    }
                }

            }
            return "https://image.flaticon.com/icons/png/512/36/36601.png";
        }
    }
}
