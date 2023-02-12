using System;
using System.Collections.Generic;
using System.Linq;
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
        const int step = 20;
        bool IsAddTail = false;
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
        public Point SetXY()
        {
            return new Point(listFragments[0].point.X, listFragments[0].point.Y);
        }
        public void MoveSnake(GameField.MoveDirect moveDirect)
        {
            if (IsAddTail == true)
            {
                IsAddTail = false;
                Fragment frag = new Fragment();
                listFragments.Add(frag);
                frag.point.X = listFragments.Last().point.X;
                frag.point.Y = listFragments.Last().point.Y;
            }

            for (int i = listFragments.Count - 1; i > 0; i--)
            {
                listFragments[i].point.X = listFragments[i - 1].point.X;
                listFragments[i].point.Y = listFragments[i - 1].point.Y;
            }


            Fragment head = listFragments[0];
            switch (moveDirect)
            {
                case GameField.MoveDirect.right:                  
                        head.point.X += 1;                  
                    break;

                case GameField.MoveDirect.up:                    
                        head.point.Y -= 1;                       
                    break;

                case GameField.MoveDirect.down:
                    head.point.Y += 1;                                       
                    break;

                case GameField.MoveDirect.left:                  
                        head.point.X -= 1;                                          
                    break;

                case GameField.MoveDirect.none:
                    return;                   
            }
            PaintSnake();
        }
        
        public void AddTail()
        {
            IsAddTail = true;
        }
        public void CheckHit()
        {
            for (int i = 1; i < listFragments.Count; i++)
            {
                if (listFragments[0].point.X == listFragments[i].point.X && listFragments[0].point.Y == listFragments[i].point.Y)
                {
                    GameField.IsCheckHit = true;
                    MessageBox.Show("Игра окончена. Змея врезалась в себя.");

                }
            }
        }
        public int Score() 
        {
            return listFragments.Count;
        }
    }
}
