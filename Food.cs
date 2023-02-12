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
        //Ellipse ellipse;
        TextBlock textBlock;
        Viewbox viewbox = new Viewbox();
        List<string> foodEmoji = new List<string>()
            { "🍉", "🍌", "🥕", "🥒", "🍅", "🍓","🍒","🍍","🥭","🍎","🍗" };
        public Food()
        {
            //ellipse = new Ellipse();
            //ellipse.Width = GameField.scaleX;
            //ellipse.Height = GameField.scaleY;
            //ellipse.Fill = Brushes.Red;
            //GameField.canvas.Children.Add(ellipse);
            Random random = new Random();
            textBlock = new TextBlock();
            
            int index = random.Next(foodEmoji.Count);
            string nextEmoji = foodEmoji[index];
            textBlock.Text = nextEmoji;
            viewbox.Child = textBlock;
            viewbox.Width = GameField.scaleX;
            viewbox.Height = GameField.scaleY;
            textBlock.FontSize = 20;
            textBlock.Foreground = Brushes.Red;
            
            GameField.canvas.Children.Add(viewbox);
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
            Canvas.SetLeft(viewbox, x * GameField.scaleX);
            Canvas.SetTop(viewbox, y * GameField.scaleY);
        }
    }
}
