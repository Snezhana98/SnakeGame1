using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeGame1
{
    class Snake
    {
        class Fragment
        {
            public Point point;
            public Rectangle rectangle;
            public Fragment()
            {
                rectangle = new Rectangle();
                rectangle.Width = GameField.scaleX;
                rectangle.Height = GameField.scaleY;
                rectangle.Fill = Brushes.Green;
                GameField.canvas.Children.Add(rectangle);
                point = new Point();
                
            }
        }

        List<Fragment> listFragments;
        public Snake(double w, double h)
        {
            listFragments = new List<Fragment>();
            Fragment fragment = new Fragment();
            fragment.point.X = w / 2;
            fragment.point.Y = h / 2;
            listFragments.Add(fragment);
        }
        
        public void PaintSnake()
        {
            foreach(Fragment fragment in listFragments)
            {
                Canvas.SetLeft(fragment.rectangle, fragment.point.X * GameField.scaleX);
                Canvas.SetTop(fragment.rectangle, fragment.point.Y * GameField.scaleY);
            }
        }
    }
}
