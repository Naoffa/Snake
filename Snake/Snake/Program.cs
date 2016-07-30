using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int mapWidth = 80;
            int mapHeight = 25;

            Console.SetBufferSize(mapWidth, mapHeight);
          //  Console.CursorVisible = false;

            Boundary boundary = new Boundary(mapWidth, mapHeight);
            boundary.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            Point startPoint = new Point(1, 12, '*');
            Snake snake = new Snake(startPoint, 4, Direction.RIGHT);
            snake.Draw();

            while (true)
            {
                if (boundary.HadCollision(snake) || snake.HadCollisionWithTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                    snake.Move();

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);                    
                    
                    while (Console.KeyAvailable) 
                        key = Console.ReadKey(true);

                    snake.HandleKey(key.Key);
                }
            }
            WriteGameOver();
            Console.ReadKey(true);
        }


        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 10;
            Console.ForegroundColor = ConsoleColor.Red;
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset, yOffset);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {            
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }


    }
}
