using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPIDotnet7.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        //All superheroes list
        List<SuperHero> GetAllSuperHeroes();

        SuperHero? GetSingleSuperHeroes(int id);

        SuperHero? AddHero([FromBody] SuperHero hero);
        List <SuperHero>? UpdateHero(int id, SuperHero request);
        List<SuperHero>? DeleteHero(int id);
    }
}
