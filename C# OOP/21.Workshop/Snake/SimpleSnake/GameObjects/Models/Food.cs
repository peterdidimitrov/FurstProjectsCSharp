using SimpleSnake.GameObjects.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects.Models
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Random random;
        //private IServiceProvider serviceProvider;
        private Wall wall;
        protected Food(Wall wall, char foodSymbol, int points) 
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            FoodPoints = points;
            random = new Random();
            //serviceProvider = ServiceConfigurator.ConfigureServices();
        }

        public int FoodPoints { get; set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            bool isPointOfSnake = snakeElements
                .Any(se => se.LeftX == LeftX && se.TopY == TopY);

            while (isPointOfSnake)
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = snakeElements
                    .Any(se => se.LeftX == LeftX && se.TopY == TopY);
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == TopY && snake.LeftX == LeftX;
        }
    }
}
