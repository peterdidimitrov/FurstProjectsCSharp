﻿using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> models;
        public BunnyRepository()
        {
            models = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => models.AsReadOnly();

        public void Add(IBunny model) => models.Add(model);

        public IBunny FindByName(string name) => models.FirstOrDefault(b => b.Name == name);

        public bool Remove(IBunny model) => models.Remove(model);
    }
}
