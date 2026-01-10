using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPIDotnet7.Models;

namespace SuperHeroAPIDotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllSuperHeroes()
        {
            var superHeroes = new List<SuperHero> {
                new SuperHero { Id = 1, Name = "Spider Man", FirstName = "Peter", LastName = "Parker", Place = "New York City" },
                new SuperHero { Id = 2, Name = "Batman", FirstName = "Bruce", LastName = "Wayne", Place = "Gotham City" }
            };

            return Ok(superHeroes);
        }
    }
}
