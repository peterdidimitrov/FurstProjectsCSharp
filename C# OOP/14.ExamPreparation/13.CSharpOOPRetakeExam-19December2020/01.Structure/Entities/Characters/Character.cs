using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double armor;
        private double baseArmor;
        private double abilityPoints;
        private Bag bag;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            Health = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }

        public double BaseHealth
        {
            get { return baseHealth; }
            protected set { baseHealth = value; }
        }

        public double Health
        {
            get { return health; }
            set
            {
                if (value < BaseHealth && value > 0)
                {
                    health = value;
                }
            }
        }
        public double BaseArmor
        {
            get { return baseArmor; }
            protected set { baseArmor = value; }
        }
        public double Armor
        {
            get { return armor; }
            private set
            {
                if (value > 0)
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints
        {
            get { return abilityPoints; }
            private set { abilityPoints = value; }
        }

        public Bag Bag
        {
            get { return bag; }
            set { bag = value; }
        }


        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (Armor >= hitPoints)
                {
                    Armor -= hitPoints;
                }
                else
                {
                    hitPoints -= Armor;
                    Armor = 0;
                }

                if (Armor == 0)
                {
                    Health -= hitPoints;
                }
                if (Health <= 0)
                {
                    IsAlive = false;
                }
            }
        }
        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }
    }
}