﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        private string species;
        private string diet;
        private double weight;
        private double length;
        public Animal(string species, string diet, double weight, double length)
        {
            Species = species;
            Diet = diet;
            Weight = weight;
            Length = length;
        }

        public string Species { get; private set; }
        public string Diet { get; private set; }
        public double Weight { get; private set; }
        public double Length { get; private set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The {Species} is a {Diet} and weighs {Weight} kg.");

            return sb.ToString().TrimEnd();
        }
    }
}
