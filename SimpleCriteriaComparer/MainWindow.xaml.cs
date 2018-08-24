using StructureMap;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SimpleCriteriaComparer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Container _container { get; set; }

        private IDrawHelper _drawHelper { get; set; }

        private IBaseHelper _helper { get; set; }

        internal bool isClose = true;
        
        public MainWindow()
        {
            InitializeComponent();
            //Cursor = new Cursor(Directory.GetCurrentDirectory() + @"\cursor.cur");
            _container = new Container(_ =>
            {
                _.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });
            });
            _drawHelper = _container.GetInstance<IDrawHelper>();
            _helper = _container.GetInstance<IBaseHelper>();
            SoulData.Initialize();
            numberCombobox.ItemsSource = SoulData.SourceAlternative;
            gradationCombobox.ItemsSource = SoulData.SourceGradation;
            toolTipInfo.Text = Strings.startData;
            numberCombobox.SelectionChanged += UpdateAlternativesStackPanel;
            numberCombobox.SelectionChanged += UpdateOpacity;
            gradationCombobox.SelectionChanged += UpdateOpacity;
        }
        
        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            if (numberCombobox.SelectedItem == null || gradationCombobox.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Для початку роботи оберіть кількість альтернатив та кількість градацій", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if(!_helper.CheckAlternativesNamesForUniques(alternativesOnStackPanel.Children))
            {
                _helper.UpdateAlternatives(SoulData.Alternatives, alternativesOnStackPanel.Children);
                SoulData.CurrentGradation = int.Parse(gradationCombobox.SelectedItem.ToString());
                QuestionWindow questionsStateWindow = new QuestionWindow(this, _container);
                _helper.InitializeColors(SoulData.Alternatives);
                questionsStateWindow.Show();
                this.Hide();
            }
        }
        
        public void BuildResult(QuestionWindow window, string isFinished)
        {
            ResultInfo details = new ResultInfo(this, window, isFinished, _container);
            details.Show();
        }
        
        private void UpdateOpacity(object sender, EventArgs e)
        {
            if (numberCombobox.SelectedItem != null && gradationCombobox.SelectedItem != null)
            {
                startInfo.Opacity = 1.0;
                startBtn.Opacity = 1.0;
            }
        }

        private void UpdateAlternativesStackPanel(object sender, EventArgs e)
        {
            startInfo.Opacity = 1.0;
            var combobox = sender as ComboBox;
            if (combobox.SelectedItem.ToString() != string.Empty)
            {
                var number = int.Parse(combobox.SelectedItem.ToString());
                if (number > SoulData.NumberOfAlternatives)
                {
                    for (int index = 0; index < number - SoulData.NumberOfAlternatives; index++)
                    {
                        var textBox = _drawHelper.DrawTextBox();
                        textBox.GotFocus += RemoveText;
                        textBox.LostFocus += AddText;

                        alternativesOnStackPanel.Children.Add(textBox);
                    }
                }
                else if (number < SoulData.NumberOfAlternatives)
                {
                    for (int index = 0; index < SoulData.NumberOfAlternatives - number; index++)
                    {
                        alternativesOnStackPanel.Children.RemoveAt(alternativesOnStackPanel.Children.Count - 1);
                    }
                }
                _container.GetInstance<IDrawHelper>().UpdateNamesForAlternatives(alternativesOnStackPanel.Children);

                SoulData.NumberOfAlternatives = number;
            }
            _helper.UpdateAlternatives(SoulData.Alternatives, alternativesOnStackPanel.Children);
        }

        private void RemoveText(object sender, EventArgs e)
        {
            var alternative = sender as TextBox;
            if (alternative.Text == string.Empty
                 || alternative.Text == "Альтернатива 1"
                 || alternative.Text == "Альтернатива 2"
                 || alternative.Text == "Альтернатива 3"
                 || alternative.Text == "Альтернатива 4"
                 || alternative.Text == "Альтернатива 5"
                 || alternative.Text == "Альтернатива 6"
                 || alternative.Text == "Альтернатива 7"
                 || alternative.Text == "Альтернатива 8"
                 || alternative.Text == "Альтернатива 9")
            {
                alternative.Text = "";
            }
        }

        private void AddText(object sender, EventArgs e)
        {
            var alternative = sender as TextBox;
            if (String.IsNullOrWhiteSpace(alternative.Text))
                alternative.Text = "Альтернатива";

            _drawHelper.UpdateNamesForAlternatives(alternativesOnStackPanel.Children);
        }

        private void GetFocusOfMouse(object sender, MouseEventArgs e)
        {
            var text = (sender as ContentControl).Content.ToString();
            switch (text)
            {
                case "К-сть альтернатив":
                    toolTipInfo.Text = Strings.alternatives;
                    break;
                case "К-сть градацій":
                    toolTipInfo.Text = Strings.gradation;
                    break;
                case "Попередження про конфлікти":
                    toolTipInfo.Text = Strings.preventConflict;
                    break;
                case "Зберегти результат":
                    toolTipInfo.Text = Strings.saveResults;
                    break;
                case "Почати ранжування":
                    toolTipInfo.Text = Strings.startButton;
                    break;
                default:
                    toolTipInfo.Text = Strings.startData;
                    break;
            }
        }

        private void LostFocusOfMouse(object sender, MouseEventArgs e)
        {
            toolTipInfo.Text = Strings.startData;
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
