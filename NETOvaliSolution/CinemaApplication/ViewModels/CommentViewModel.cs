using CinemaApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace CinemaApplication.ViewModels
{
    public class CommentViewModel : INotifyPropertyChanged
    {
        int i = 0;

        public FilmModel Film { get; set; }
        public ICommand cmdClick { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        //public String rech { get; set; }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

      /*  private async void NextPage()
        {
            Client ac = new Client("http://localhost:53454/swagger/v1/swagger.json", new System.Net.Http.HttpClient());


            using (var httpClient = new HttpClient())
            {
                i++;
                using (var response = await httpClient.GetAsync("http://localhost:53454/api/film/all?page=" + i + "&pagesize=" + 5))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var f = JsonConvert.DeserializeObject<List<LibraryDTO.FullFilmDTO>>(apiResponse);
                    Films.Clear();
                    foreach (var ff in f)
                    {
                        Films.Add(new FilmModel(ff.Posterpath, ff.Title, ff.Runtime, null, ff.CommentsD));
                    }
                }
            }
        }
      */
        public CommentViewModel()
        {
           // cmdClick = new DelegateCommand((a) => NextPage());
           // Film = new FilmModel();

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