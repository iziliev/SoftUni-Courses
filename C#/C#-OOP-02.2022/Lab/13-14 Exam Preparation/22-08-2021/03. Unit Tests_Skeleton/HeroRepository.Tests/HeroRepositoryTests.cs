using System;
using NUnit.Framework;


public class HeroRepositoryTests
{
    [Test]
    public void CreateHero()
    {
        var hero = new Hero("Ivo", 15);

        Assert.AreEqual("Ivo", hero.Name);
        Assert.AreEqual(15, hero.Level);
    }

    [Test]
    public void CreateHeroRepo()
    {
        var repo = new HeroRepository();

        Assert.AreEqual(0, repo.Heroes.Count);
    }

    [Test]
    public void CreateHeroinRepo()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Ivo", 15);
        var hero1 = new Hero("Ivo1", 18);
        var hero2 = new Hero("Ivo2", 158);

        Assert.AreEqual($"Successfully added hero Ivo with level 15", repo.Create(hero));
        Assert.AreEqual($"Successfully added hero Ivo1 with level 18", repo.Create(hero1));
        Assert.AreEqual($"Successfully added hero Ivo2 with level 158", repo.Create(hero2));

        Assert.AreEqual(3, repo.Heroes.Count);

    }

    [Test]
    public void CreateHeroNullinRepo()
    {
        var repo = new HeroRepository();
        Hero hero = null;
        Assert.Throws<ArgumentNullException>(() => repo.Create(hero));
    }

    [Test]
    public void CreateSameHeroinRepo()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Ivo", 15);

        repo.Create(hero);

        Assert.Throws<InvalidOperationException>(() => repo.Create(new Hero("Ivo", 15)));
    }

    [Test]
    public void CreateRemoveHeroinRepo()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Ivo", 15);
        var hero1 = new Hero("Ivo1", 18);
        var hero2 = new Hero("Ivo2", 158);

        repo.Create(hero);
        repo.Create(hero1);
        repo.Create(hero2);

        Assert.Throws<ArgumentNullException>(()=>repo.Remove(null));

    }
    [Test]
    public void CreateRemoveHeroinRep2o()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Ivo", 15);
        var hero1 = new Hero("Ivo1", 18);
        var hero2 = new Hero("Ivo2", 158);

        repo.Create(hero);
        repo.Create(hero1);
        repo.Create(hero2);

        Assert.Throws<ArgumentNullException>(() => repo.Remove(""));

    }

    [Test]
    public void CreateRemoveHeroinRep3o()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Ivo", 15);
        var hero1 = new Hero("Ivo1", 18);
        var hero2 = new Hero("Ivo2", 158);

        repo.Create(hero);
        repo.Create(hero1);
        repo.Create(hero2);

        Assert.Throws<ArgumentNullException>(() => repo.Remove(" "));

    }

    [Test]
    public void CreateRemoveTrueHeroinRepo()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Ivo", 15);
        var hero1 = new Hero("Ivo1", 18);
        var hero2 = new Hero("Ivo2", 158);

        repo.Create(hero);
        repo.Create(hero1);
        repo.Create(hero2);

        Assert.IsTrue(repo.Remove("Ivo1"));
        Assert.AreEqual(2, repo.Heroes.Count);

    }

    [Test]
    public void CreateR8emoveTrueHeroinRepo()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Ivo", 15);
        var hero1 = new Hero("Ivo1", 18);
        var hero2 = new Hero("Ivo2", 158);

        repo.Create(hero);
        repo.Create(hero1);
        repo.Create(hero2);

        Assert.IsFalse(repo.Remove("Ivo85"));
        Assert.AreEqual(3, repo.Heroes.Count);

    }

    [Test]
    public void CreateRemoveTrueHeroinRepo1()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Ivo", 15);
        var hero1 = new Hero("Ivo1", 18);
        var hero2 = new Hero("Ivo2", 158);

        repo.Create(hero);
        repo.Create(hero1);
        repo.Create(hero2);

        Assert.AreEqual(hero2, repo.GetHeroWithHighestLevel());

    }
    [Test]
    public void CreateRemoveTru4eHeroinRepo1()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Ivo", 15);
        var hero1 = new Hero("Ivo1", 18);
        var hero2 = new Hero("Ivo2", 158);

        repo.Create(hero);
        repo.Create(hero1);
        repo.Create(hero2);

        Assert.AreEqual(hero1, repo.GetHero("Ivo1"));

    }
}