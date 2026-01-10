using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPIDotnet7.Models;

namespace SuperHeroAPIDotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

            private static List<SuperHero> superHeroes = new List<SuperHero> {
                new SuperHero { Id = 1, Name = "Spider Man", FirstName = "Peter", LastName = "Parker", Place = "New York City" },
                new SuperHero { Id = 2, Name = "Batman", FirstName = "Bruce", LastName = "Wayne", Place = "Gotham City" }
            };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllSuperHeroes()
        {
            return Ok(superHeroes);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleSuperHeroes(int id)
        {
            var hero = superHeroes.Find(s => s.Id == id);
            if(hero == null)
            {
                return NotFound("No SuperHero found. Please enter a new ID.");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero([FromBody]SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var hero = superHeroes.Find(s => s.Id == request.Id);
            if (hero == null)
            {
                return NotFound("No SuperHero found. Please enter a new ID.");
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;
            return Ok(superHeroes);
        }
    }
}
