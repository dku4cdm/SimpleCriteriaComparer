using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace SimpleCriteriaComparer
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private bool isClose = true;

        public StartWindow()
        {
            InitializeComponent();
            startTextBlock.Text = Strings.startGreetings;
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            isClose = false;
            window.Show();
            this.Close();
        }
        
        private void ExitClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isClose)
            {
                var dialogResult = MessageBox.Show("Ви дійсно хочете вийти з програми?", "Вихід з програми", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                switch (dialogResult)
                {
                    case MessageBoxResult.Yes:
                        break;
                    case MessageBoxResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
