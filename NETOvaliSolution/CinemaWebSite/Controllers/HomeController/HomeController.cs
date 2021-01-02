using CinemaWebSite.Models;
using CinemaWebSite.Services;
//using CinemaWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CinemaWebSite.HomeController;

namespace CinemaWebSite.HomeController
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("/{page}")]
        public async Task<IActionResult> IndexAsync(int page)
        {
            if (page == 0)
                page = 1;
            ICollection<HomeFilmModel> Films = new List<HomeFilmModel>();

            Client ac = new Client("http://localhost:53454/swagger/v1/swagger.json", new System.Net.Http.HttpClient());


            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:53454/api/film/all?page=" + page + "&pagesize=" + 5))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var f = JsonConvert.DeserializeObject<List<LibraryDTO.FullFilmDTO>>(apiResponse);
                    Films.Clear();
                    foreach (var ff in f)
                    {
                        Films.Add(new HomeFilmModel(ff.Id, ff.Posterpath, ff.Title, ff.Runtime, ff.Vote_Average, page));
                    }
                }
            }
            return View(Films);
        }
        [Route("/film/{id}/{page}")]
        public async Task<IActionResult> DetailsFilm(int id, int page)
        {
            if (id == 0)
                id = 1;
            if (page == 0)
                page = 1;
            DetailFilmModel Film = new DetailFilmModel();
            Client ac = new Client("http://localhost:53454/swagger/v1/swagger.json", new System.Net.Http.HttpClient());

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:53454/api/film/" + id + "/details?page=" + page + "&pagesize=" + 5))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var f = JsonConvert.DeserializeObject<List<LibraryDTO.FullFilmDTO>>(apiResponse);
                    foreach (var ff in f)
                        Film = new DetailFilmModel(ff.Id, ff.Title, ff.Vote_Average, ff.Runtime, ff.Posterpath, page,
                                     ff.CommentsD, ff.FilmTypelist, ff.Actors);
                }
            }
            return View(Film);
        }
        [Route("/film/{id}/comment")]
        public async Task<ActionResult> AddComment(int id, string content, string username, string rate)
        {
            Client ac = new Client("http://localhost:53454/swagger/v1/swagger.json", new System.Net.Http.HttpClient());
            var cont = new StringContent('"' + content + '"', Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync("http://localhost:53454/api/Comment/film/" + id + "?note=" + rate + "&user=" + username, cont))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return Redirect("/film/" + id + "/0");
            //return RedirectToAction(id.ToString()+"/0", "film");
        }

        [Route("/film/search/")]
        public async Task<ActionResult> SearchFilm(string title, string[] check, string name, string surname = "")
        {
            Client ac = new Client("http://localhost:53454/swagger/v1/swagger.json", new System.Net.Http.HttpClient());
            int id = 0;
            if (surname == null)
                surname = "";
            if (check.Length > 1 || check.Length < 0)
            {
                return Redirect("/");
            }
            else
            if (check[0] == "1")
            {
                var cont = new StringContent('"' + title + '"', Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync("http://localhost:53454/api/Film/name", cont))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var f = JsonConvert.DeserializeObject<LibraryDTO.FullFilmDTO>(apiResponse);
                        if (f == null)
                        {
                            return Redirect("/");
                        }
                        else id = f.Id;
                    }
                }
            }
            else
            if (check[0] == "2")
            {
                ICollection<HomeFilmModel> Films = new List<HomeFilmModel>();

                string nom = "name=" + name;
                if (surname != "")
                {
                    nom += "&surname=" + surname;
                }
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:53454/api/Film/name?" + nom))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var errors = new List<string>();
                        var f = JsonConvert.DeserializeObject<List<LibraryDTO.FilmDTO>>(apiResponse,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Include,
                            Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs earg)
                            {
                                errors.Add(earg.ErrorContext.Member.ToString());
                                earg.ErrorContext.Handled = true;
                            }
                        });
                        if (f == null)
                        {
                            return Redirect("/");
                        }
                        else
                        {
                            Films.Clear();
                            foreach (var ff in f)
                            {
                                Films.Add(new HomeFilmModel(ff.Id, ff.Posterpath, ff.Title, ff.Runtime, ff.Vote_Average, 0));
                            }
                            return View(Films);
                        }
                    }
                }
            }

            return Redirect("/film/" + id + "/0");
        }
        [Route("/ActorC/{id}")]
        public async Task<ActionResult> ActorPage(int id)
        {
            ActorController act = new ActorController();
            return (ActionResult)await act.ActorPage(id);
        }
    }
}
