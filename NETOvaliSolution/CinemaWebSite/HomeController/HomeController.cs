using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaWebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWebSite.HomeController
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ICollection<HomeFilmModel> film = new List<HomeFilmModel>
            {
                new HomeFilmModel(1, "img", "El Filmoo", 136, 3.2, 100),
                new HomeFilmModel(1, "blabla", "LE FILM", 137, 2.2, 400),
                new HomeFilmModel(1, "img", "THE MOVIE", 138, 4.2, 600)

            };
            return View(film);
        }
    }
}
