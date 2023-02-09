using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeGame1
{
    public class Food
    {
        int x, y;
        Ellipse ellipse;
        public Food()
        {
            ellipse = new Ellipse();
            ellipse.Width = GameField.scaleX;
            ellipse.Height = GameField.scaleY;
            ellipse.Fill = Brushes.Red;
            GameField.canvas.Children.Add(ellipse);
        }


        public Point FoodGeneration()
        {
            Random random = new Random();
            x = random.Next(0, 19);
            y = random.Next(0, 19);
            return new Point(x, y);
        }
        public void PaintFood()
        {
            Canvas.SetLeft(ellipse, x * GameField.scaleX);
            Canvas.SetTop(ellipse, y * GameField.scaleY);
        }
    }
}
