using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows.Controls;

namespace SnakeGame1
{
    public class GameField
    {
        readonly int w = 20, h = 20;
        Snake snake;
        Food food;
        public static Canvas canvas;
        public static double scaleX, scaleY;
        public GameField(Canvas canv)
        {
            canvas = canv;
            scaleX = canv.ActualWidth / w;
            scaleY = canv.ActualHeight / h;
        }
        public void Start()
        {
            food = new Food();
            food.FoodGeneration();
            food.PaintFood();

            snake = new Snake(w, h);
            snake.PaintSnake();
        }

        public void timer()
        {
            Timer time = new Timer();
            time.Interval = 1000;
        }
    }
}
