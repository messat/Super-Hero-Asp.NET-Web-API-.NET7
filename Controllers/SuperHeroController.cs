using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPIDotnet7.Services.SuperHeroService;

namespace SuperHeroAPIDotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllSuperHeroes()
        {
            return _superHeroService.GetAllSuperHeroes();

        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleSuperHeroes(int id)
        {
            var result = _superHeroService.GetSingleSuperHeroes(id);
            if(result == null)
            {
                return NotFound("No Super Hero found. Please try again.");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero([FromBody]SuperHero hero)
        {
            var result = _superHeroService.AddHero(hero);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var result = _superHeroService.UpdateHero(id, request);
            if(result is null)
            {
                return NotFound("No Super Hero found to update. Please try again.");
            }
            return Ok(result);
           
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = _superHeroService.DeleteHero(id);
            if(result is null)
            {
                return NotFound("Superhero ID not found. Please try again");
            }
            return Ok(result);
        }
    }
}
