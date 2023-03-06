﻿using System;
using System.Linq;
using BorderControl.Models.Interfaces;

namespace BorderControl.Models;

public class Robot : IPassers
{
    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }

    public string Model { get; private set; }
    public string Id { get; private set; }

}