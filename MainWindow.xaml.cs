using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeGame1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameField main;
        public MainWindow()
        {
            InitializeComponent();           
        }

        private void OnClickStart(object sender, RoutedEventArgs e)
        {
            
            main = new GameField(canvas, grid);
            
            main.Start();
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    main.k = GameField.MoveDirect.up;
                    break;
                case Key.S:
                    main.k = GameField.MoveDirect.down;
                    break;
                case Key.D:
                    main.k = GameField.MoveDirect.right;
                    break;
                case Key.A:
                    main.k = GameField.MoveDirect.left;
                    break;
            }
        }

        private void OnClickStop(object sender, RoutedEventArgs e)
        {
            main.timerStop();
        }

        private void OnClickContinue(object sender, RoutedEventArgs e)
        {
            main.timerContinue();
        }
    }
}
