using CinemaWebSite.Models;
using CinemaWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace CinemaWebSite.HomeController
{
    public class ActorController : Controller
    {
        [Route("[Controller]/{id}")]
        public async Task<IActionResult> ActorPage(int id)
        {
            ActorModel actor = new ActorModel();
            Client ac = new Client("http://localhost:53454/swagger/v1/swagger.json", new System.Net.Http.HttpClient());
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.themoviedb.org/3/person/" + id + "?api_key=e114b4b6e70060d6cae8ab490839fc18&language=fr-BE"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var errors = new List<string>();
                    var f = JsonConvert.DeserializeObject<ActorModel>(apiResponse,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Include,
                            Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs earg)
                            {
                                errors.Add(earg.ErrorContext.Member.ToString());
                                earg.ErrorContext.Handled = true;
                            }
                        });
                    int age = 0;
                    if (f.Deathday.CompareTo(new DateTime(1,1,1))==0)
                    {
                        // Save today's date.
                        var today = DateTime.Today;

                        // Calculate the age.
                        age = today.Year - f.Birthday.Year;

                        // Go back to the year in which the person was born in case of a leap year
                        if (f.Birthday.Date > today.AddYears(-age)) age--;
                    }
                    else
                    {
                        var today = DateTime.Today;

                        // Calculate the age.
                        age = f.Deathday.Year - f.Birthday.Year;

                        // Go back to the year in which the person was born in case of a leap year
                        if (f.Birthday.Date > f.Deathday.AddYears(-age)) age--;
                    }
                    actor = new ActorModel(id, f.Name, f.Biography, f.Profile_path, f.Birthday, age);
                }
            }
            return View(actor);
        }
    }
}
