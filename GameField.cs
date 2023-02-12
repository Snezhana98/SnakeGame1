using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace SnakeGame1
{
    public class GameField
    {
        readonly int w = 20, h = 20;
        Snake snake;
        Food food;
        public static Canvas canvas;
        static Grid grid;
        public static double scaleX, scaleY;
        public enum MoveDirect { none, up, down, right, left };
        public MoveDirect k;
        DispatcherTimer time;
        TextBlock textBlock;
        public GameField(Canvas canv, Grid grid1)
        {
            canvas = canv;
            grid = grid1;
            
            scaleX = canv.ActualWidth / w;
            scaleY = canv.ActualHeight / h;
            

            snake = new Snake(w, h);
            food = new Food();
        }
        public void Start()
        {
            food.FoodGeneration();
            food.PaintFood();

            snake.PaintSnake();
            time = new DispatcherTimer();
            time.Interval = new TimeSpan(0, 0, 0, 0, 300);
            time.Start();
            time.Tick += Time_Tick;
        }

        public void timerContinue()
        {
            time.Start();
        }

        public void timerStop()
        {

            time.Stop();
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            snake.MoveSnake(k);
            Check();
            SnakeScore();
        }
        public static bool IsCheckHit = false;
        public void Check()
        {

            Point CoordFood = food.SetXY();
            Point CoordSnake = snake.SetXY();
            if (CoordFood == CoordSnake)
            {
                food.FoodClear();
                food = new Food();
                food.FoodGeneration();
                food.PaintFood();
                snake.AddTail();
            }
            if (CoordSnake.X < 0 || CoordSnake.X == w || CoordSnake.Y < 0 || CoordSnake.Y == h)
            {
                timerStop();
                MessageBox.Show("Игра окончена. Змея врезалась в стену.");
            }
            snake.CheckHit();
            if (IsCheckHit == true)
            {
                timerStop();
            }
            grid.Children.Remove(textBlock);

        }

        public void SnakeScore() 
        {
            
            int k = snake.Score();
            
            textBlock = new TextBlock();
            textBlock.Text = k.ToString();
            textBlock.FontSize = 20;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(textBlock);
            Grid.SetColumn(textBlock, 3);
        }
    }
}
