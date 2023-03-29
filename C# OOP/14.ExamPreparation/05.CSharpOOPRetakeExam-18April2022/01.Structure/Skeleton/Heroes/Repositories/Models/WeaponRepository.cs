using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories.Models
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;
        public WeaponRepository()
        {
            this.weapons  =  new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.weapons.AsReadOnly();

        public void Add(IWeapon model) => weapons.Add(model);

        public IWeapon FindByName(string name) => this.weapons.FirstOrDefault(w => w.Name == name);

        public bool Remove(IWeapon model) => this.weapons.Remove(this.weapons.FirstOrDefault(w => w == model));
        }
}
