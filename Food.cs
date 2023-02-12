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
        
        TextBlock textBlock;
        Viewbox viewbox = new Viewbox();


        List<string> foodEmoji = new List<string>()
            { "🍉", "🍌", "🥕", "🥒", "🍅", "🍓","🍒","🍍","🥭","🍎","🍗" };
        public Food()
        {
            Random random = new Random();
            textBlock = new TextBlock();
            int index = random.Next(foodEmoji.Count);
            string nextEmoji = foodEmoji[index];
            textBlock.Text = nextEmoji;
            textBlock.FontSize = 20;
            textBlock.Foreground = Brushes.Red;

            viewbox.Child = textBlock;
            viewbox.Width = GameField.scaleX;
            viewbox.Height = GameField.scaleY;

            
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
        public Point SetXY()
        {
            return new Point(x, y);
        }

        public void FoodClear()
        {
            GameField.canvas.Children.Remove(viewbox);
        }
    }
}
