﻿using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        public IReadOnlyCollection<IEquipment> Models => throw new NotImplementedException();

        public void Add(IEquipment model)
        {
            throw new NotImplementedException();
        }

        public IEquipment FindByType(string type)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IEquipment model)
        {
            throw new NotImplementedException();
        }
    }
}
