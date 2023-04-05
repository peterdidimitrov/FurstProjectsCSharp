﻿using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> models;
        public EggRepository()
        {
            models = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => models.AsReadOnly();

        public void Add(IEgg model) => models.Add(model);

        public IEgg FindByName(string name) => models.FirstOrDefault(e => e.Name == name);

        public bool Remove(IEgg model) => models.Remove(model);
    }
}
