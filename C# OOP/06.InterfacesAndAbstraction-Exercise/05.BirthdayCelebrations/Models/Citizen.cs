using System;
using System.Linq;
using BirthdayCelebrations.Models.ICallable;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Models;

public class Citizen : IPassers, IBorn
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
}