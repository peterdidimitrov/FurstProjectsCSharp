﻿using TemplatePattern.Models;

namespace TemplatePattern
{
    public class StartUp
    {
        public static void Main()
        {
            Sourdough sourdough = new Sourdough();
            sourdough.Make();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}