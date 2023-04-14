﻿using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;
        public RaceRepository()
        {
            models = new List<IRace>();
        }
        public void Add(IRace model) => models.Add(model);

        public IReadOnlyCollection<IRace> GetAll() => models.AsReadOnly();

        public IRace GetByName(string name) => models.FirstOrDefault(m => m.Name == name);

        public bool Remove(IRace model) => models.Remove(model);
    }
}
