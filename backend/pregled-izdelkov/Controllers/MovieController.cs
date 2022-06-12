using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace movie_list.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        //Lista filmov, ki bo vedno enaka, ko se server ponovno zažene -> nujno STATIC !
        private static List<Movie> movies = new List<Movie>{
            new Movie
            {
                id = 1,
                title = "The Godfather",
                author = "Mario Puzo",
                lenghtMin = 175,
                genre = "drama"
            },
            new Movie
            {
                id = 2,
                title = "The Conjuring",
                author = "Chad Hayes",
                lenghtMin = 112,
                genre = "grozljivka"
            },
            new Movie
            {
                id = 3,
                title = "Forrest Gump",
                author = "Nekdo",
                lenghtMin = 142,
                genre = "drama"
            }
            };

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        //GET request za pridobitev vseh filmov
        [HttpGet]
        [Route("getAllMovies")]

        //Action Result določa za kakšen tip vračanja ob requestu gre
        public ActionResult Get()
        {
            return Ok(movies);  //vrne status 200, ki pošlje poleg code 200 še json podatke
        }

        //POST  request za dodajanje novega filma in vračanje vseh
        [HttpPost]
        [Route("addMovie")]
        public ActionResult Post(Movie movie)
        {   
            movie.id = movies.Count + 1;
            movies.Add(movie);
            return Ok(movies);  //vrne vse filme z novo dodanim
        }
    }
}