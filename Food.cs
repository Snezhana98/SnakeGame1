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
        TextBlock foodText = new TextBlock();
        List<string> foodEmoji = new List<string>()
            { "🍉", "🍌", "🥕", "🥒", "🍅", "🍓","🍒","🍍","🥭","🍎","🍗" };
        public Food(TextBlock textBlock)
        {
            //ellipse = new Ellipse();
            //ellipse.Width = GameField.scaleX;
            //ellipse.Height = GameField.scaleY;
            //ellipse.Fill = Brushes.Red;
            //GameField.canvas.Children.Add(ellipse);
            Random random = new Random();
            int index = random.Next(foodEmoji.Count);
            string nextEmoji = foodEmoji[index];
            textBlock.Text = nextEmoji;
            textBlock.Width = GameField.scaleX;
            textBlock.Height = GameField.scaleY;
            foodText = textBlock;
            GameField.canvas.Children.Add(textBlock);
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
            Canvas.SetLeft(foodText, x * GameField.scaleX);
            Canvas.SetTop(foodText, y * GameField.scaleY);
        }
    }
}
