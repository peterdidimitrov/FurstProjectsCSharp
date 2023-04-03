using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void CreateAddOneHeroToRepository()
    {
        Hero hero = new Hero("Superman", 10);
        HeroRepository heroRepository = new HeroRepository();
        
        var result = heroRepository.Create(hero);

        Assert.That(heroRepository.Heroes.Count, Is.EqualTo(1));
        Assert.That(result, Is.EqualTo($"Successfully added hero {hero.Name} with level {hero.Level}"));
    }
    [Test]
    public void CreateShouldThowsArgumentNullExceptionIfHeroIsNull()
    {
        Hero hero = null;
        HeroRepository heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(hero), "Hero is null");
    }
    [Test]
    public void CreateShouldThowsInvalidOperationExceptionIfHeroIsExists()
    {
        Hero hero = new Hero("Superman", 10);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero), $"Hero with name {hero.Name} already exists");
    }
    [Test]
    public void RemoveShouldRemoveOneHero()
    {
        Hero hero = new Hero("Superman", 10);
        HeroRepository heroRepository = new HeroRepository();

        var result = heroRepository.Remove("Superman");

        Assert.That(heroRepository.Heroes.Count, Is.EqualTo(0));
    }
    [Test]
    public void RemoveShouldThowsArgumentNullExceptionIfHerosNameIsNull()
    {
        Hero hero = new Hero("Superman", 10);
        HeroRepository heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null), "Name cannot be null");
    }
    [Test]
    public void GetHeroWithHighestLevelShouldReturnHero()
    {
        Hero hero = new Hero("Superman", 10);
        Hero hero1 = new Hero("Batman", 9);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);
        heroRepository.Create(hero1);

        var result = heroRepository.GetHeroWithHighestLevel();
        var result2 = heroRepository.GetHero("Superman");

        Assert.That(result, Is.EqualTo(hero));
        Assert.That(result2, Is.EqualTo(hero));
    }
}