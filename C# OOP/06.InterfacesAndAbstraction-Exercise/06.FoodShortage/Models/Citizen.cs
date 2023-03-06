using System;
using System.Linq;
using FoodShortage.Models.Interfaces;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models;

public class Citizen : IPassers, IBorn, IBuyer
{
    public Citizen(string name, int age, string id, string date)
    {
        Name = name;
        Age = age;
        Id = id;
        Date = date;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; private set; }
    public string Date { get; private set; }

    public int Food { get; set; }

    public int Buy() => Food += 10;
}