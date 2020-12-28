using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CinemaWebSite.Models;
using CinemaWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CinemaWebSite.HomeController
{
    public class HomeController : Controller
    {
        int i = 0;
        [Route("")]
        [Route("/{page}")]
        public async Task<IActionResult> IndexAsync(int page)
        {
            if (page == 0)
                page = 1;
            /*
            ICollection<HomeFilmModel> film = new List<HomeFilmModel>
            {
                new HomeFilmModel(1, "img", "El Filmoo", 136, 3.2, 100),
                new HomeFilmModel(1, "blabla", "LE FILM", 137, 2.2, 400),
                new HomeFilmModel(1, "img", "THE MOVIE", 138, 4.2, 600)

            };
            return View(film);
            */
            ICollection<HomeFilmModel> Films = new List<HomeFilmModel>();

            Client ac = new Client("http://localhost:53454/swagger/v1/swagger.json", new System.Net.Http.HttpClient());


            using (var httpClient = new HttpClient())
            {
                i++;
                using (var response = await httpClient.GetAsync("http://localhost:53454/api/film/all?page=" + page + "&pagesize=" + 5))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var f = JsonConvert.DeserializeObject<List<FullFilmDTO>>(apiResponse);
                    Films.Clear();
                    foreach (var ff in f)
                    {
                        Films.Add(new HomeFilmModel(ff.Id, ff.Posterpath, ff.Title, ff.Runtime, ff.Vote_Average,page));
                    }
                }
            }
            return View(Films);
        }
    }
}
