﻿namespace SimpleSnake.GameObjects.Models;

public class FoodHash : Food
{
    private const char FoodSymbol = '#';
    private const int Points = 3;
    public FoodHash(Wall wall) 
        : base(wall, FoodSymbol, Points)
    {
    }
}
