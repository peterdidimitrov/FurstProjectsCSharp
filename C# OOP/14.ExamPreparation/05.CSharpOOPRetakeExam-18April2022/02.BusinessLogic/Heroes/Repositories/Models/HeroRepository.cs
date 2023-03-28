﻿using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories.Models
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;
        public HeroRepository()
        {
            heroes = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => this.heroes;

        public void Add(IHero model) => heroes.Add(model);

        public IHero FindByName(string name) => this.heroes.FirstOrDefault(h => h.Name == name);

        public bool Remove(IHero model) => this.heroes.Remove(this.heroes.FirstOrDefault(h => h == model));
    }
}
