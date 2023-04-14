﻿using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private readonly List<IRobot> models;
        public void AddNew(IRobot model) => models.Add(model);

        public IRobot FindByStandard(int interfaceStandard) => models.FirstOrDefault(r => r.InterfaceStandards.Contains(interfaceStandard));
        public IReadOnlyCollection<IRobot> Models() => models.AsReadOnly();

        public bool RemoveByName(string typeName)
        {
            var robot = models.FirstOrDefault(r => r.Model == typeName);
            if (robot == null)
            {
                return false;
            }
            return true;
        }
    }
}
