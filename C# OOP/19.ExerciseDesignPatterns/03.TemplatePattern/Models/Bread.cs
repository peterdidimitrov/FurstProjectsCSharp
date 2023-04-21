﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePattern.Models
{
    public abstract class Bread
    {
        public abstract void MixIngredients();
        public abstract void Bake();
        public virtual void Slice()
        {
            Console.WriteLine($"Slice the {GetType().Name} bread!");
        }
        // The template method
        public void Make()
        {
            MixIngredients();
            Bake();
            Slice();
        }
    }
}
