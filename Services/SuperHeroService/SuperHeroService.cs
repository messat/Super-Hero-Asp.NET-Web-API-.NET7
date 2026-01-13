using Microsoft.AspNetCore.Mvc;
using SuperHeroAPIDotnet7.Controllers;


namespace SuperHeroAPIDotnet7.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private static List<SuperHero> superHeroes = new List<SuperHero> {
                new SuperHero { Id = 1, Name = "Spider Man", FirstName = "Peter", LastName = "Parker", Place = "New York City" },
                new SuperHero { Id = 2, Name = "Batman", FirstName = "Bruce", LastName = "Wayne", Place = "Gotham City" }
            };


        public SuperHero? AddHero([FromBody] SuperHero hero)
        {
            superHeroes.Add(hero);
            return hero;
        }

        public List<SuperHero>? DeleteHero(int id)
        {
            var hero = superHeroes.FirstOrDefault(s => s.Id == id);
            if (hero == null)
            {
                return null;
            }
            superHeroes.Remove(hero);
            return superHeroes;
        }

        public List<SuperHero> GetAllSuperHeroes()
        {
            return superHeroes;
        }

        public SuperHero? GetSingleSuperHeroes(int id)
        {
            var hero = superHeroes.Find(s => s.Id == id);
            if (hero == null)
            {
                return null;
            }
            return hero;
        }

        public List<SuperHero>? UpdateHero(int id, SuperHero request)
        {
            var hero = superHeroes.Find(s => s.Id == request.Id);
            if (hero == null)
                return null;

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;
            return superHeroes;
        }
    }
}
