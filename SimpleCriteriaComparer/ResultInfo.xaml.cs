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
using System.Windows.Shapes;
using PieControls;
using Xceed.Wpf.Toolkit;
using System.Drawing;
using System.IO;
using System.Threading;
using StructureMap;

namespace SimpleCriteriaComparer
{
    /// <summary>
    /// Логика взаимодействия для ResultInfo.xaml
    /// </summary>
    public partial class ResultInfo : Window
    {
        private bool isClose = true;

        private string PathToSaveResults { get; set; }

        private Dictionary<int, Dictionary<string, CirclePoint>> Data { get; set; }

        private double Total { get; set; }

        private List<Tuple<string, double, double>> RankingData { get; set; }

        private Dictionary<string, Dictionary<int, Dictionary<string, CirclePoint>>> DataForAlternatives { get; set; }

        private PieDataCollection<PieSegment> _collectionList = new PieDataCollection<PieSegment>();

        private KeyValuePair<int, Dictionary<string, CirclePoint>> lastRanking { get; set; }

        private MainWindow WindowOwner { get; set; }

        private QuestionWindow WorkWindow { get; set; }

        private Container _container { get; set; }
        
        private ResultInfo()
        {
            InitializeComponent();
        }
        
        private const double _advSLow = 0.5;
        private const double _advLow = 1;
        private const double _advEq = 1;
        private const double _advHigh = 1;
        private const double _advSHigh = 2;

        private const double _specialCoef = 1.07;
        
        public ResultInfo(MainWindow window, QuestionWindow workWindow, string isFinished, Container container)
        {
            Total = default(int);
            _container = container;
            RankingData = new List<Tuple<string, double, double>>();
            DataContext = this;
            WindowOwner = window;
            WorkWindow = workWindow;
            InitializeComponent();
            if (isFinished == "true")
            {
                continueWork.Visibility = Visibility.Collapsed;
                startInstructions.Content = $"Спектри переваг альтернатив (результуючі ранжування)";
            }
            else
            {
                lastRanking = SoulData.Storage.LastOrDefault();
                SoulData.Storage.Remove(SoulData.TotalRankings - int.Parse(isFinished) + 1);
                startInstructions.Content = $"Спектри переваг альтернатив (проміжні результати): залишилось {isFinished} ранжування(-нь) з {SoulData.TotalRankings}";
            }
            Data = SoulData.Storage;
            infoBox.Text = Strings.startData;
            DrawHistogram();
            allListsBox.ItemsSource = SoulData.Alternatives.ToArray();
            allListsBox.SelectedIndex = 0;
            ConvertDataForOneAlternative(SoulData.Alternatives);
            Charts.Width = 300 + SoulData.Alternatives.Count * 100;
            
        }

        private void SetColumnName()
        {
            dataGrid.Columns[0].Header = "Назва альтернативи";
            dataGrid.Columns[1].Header = "Центроване значення";
            dataGrid.Columns[2].Header = "Нормоване значення";
            foreach (DataGridColumn column in dataGrid.Columns)
            {
                column.CanUserSort = false;
                var headerStyle = new Style();
                headerStyle.Resources.Add("FontWeight", "Bold");
                headerStyle.Resources.Add("FontSize", "16");
                headerStyle.Resources.Add("Font-Family", "Arial");
                headerStyle.Resources.Add("Foreground", "Green");
                headerStyle.Resources.Add("HorizontalContentAlignment", "Center");
                column.HeaderStyle = headerStyle;
            }
        }
        
        private void DrawHistogram()
        {
            var storage = new Dictionary<string, int[]>();
            SoulData.Alternatives.ForEach(x=>storage.Add(x,new int[5]));
            foreach (var step in Data)
            {
                foreach (var item in step.Value)
                {
                    foreach (var element in step.Value)
                    {
                        if (item.Value != element.Value)
                        {
                            double expectedRelation = item.Value.distance / element.Value.distance;
                            if (expectedRelation <= _advSLow)
                                storage[item.Key][0]++;
                            else if (expectedRelation < _advLow)
                                storage[item.Key][1]++;
                            else if (expectedRelation == _advEq)
                                storage[item.Key][2]++;
                            else if (expectedRelation >= _advSHigh)
                                storage[item.Key][4]++;
                            else if (expectedRelation > _advHigh)
                                storage[item.Key][3]++;
                        }
                    }
                }
            }

            foreach (var item in storage)
            {
                Total += Math.Pow(_specialCoef, ((-2) * item.Value[0] + (-1) * item.Value[1] + (0) * item.Value[2] + (1) * item.Value[3] + (2) * item.Value[4]));
            }

            var counter = 0;

            var modifier = 100;

            storage = storage.OrderByDescending(x => x.Value.GetMultipleArray()).ToDictionary();

            foreach (var item in storage)
            {
                if (Total == default(int))
                {
                    Total = 1;
                }
                
                var lineA = DrawLine(476 - item.Value[0] * modifier / SoulData.Alternatives.Count, counter + 40 + 0 * 25, Colors.Blue);
                Charts.Children.Add(lineA);
                var indexA = DrawIndex(item.Value[0], counter + 40 + 0 * 25, 480 - item.Value[0] * modifier / SoulData.Alternatives.Count - 22, Colors.Blue);
                Charts.Children.Add(indexA);

                var lineB = DrawLine(476 - item.Value[1] * modifier / SoulData.Alternatives.Count, counter + 40 + 1 * 25, Colors.SkyBlue);
                Charts.Children.Add(lineB);
                var indexB = DrawIndex(item.Value[1], counter + 40 + 1 * 25, 480 - item.Value[1] * modifier / SoulData.Alternatives.Count - 22, Colors.SkyBlue);
                Charts.Children.Add(indexB);

                var lineC = DrawLine(476 - item.Value[2] * modifier / SoulData.Alternatives.Count, counter + 40 + 2 * 25, Colors.White);
                Charts.Children.Add(lineC);
                var indexC = DrawIndex(item.Value[2], counter + 40 + 2 * 25, 480 - item.Value[2] * modifier / SoulData.Alternatives.Count - 22, Colors.White);
                Charts.Children.Add(indexC);

                var lineD = DrawLine(476 - item.Value[3] * modifier / SoulData.Alternatives.Count, counter + 40 + 3 * 25, Colors.Plum);
                Charts.Children.Add(lineD);
                var indexD = DrawIndex(item.Value[3], counter + 40 + 3 * 25, 480 - item.Value[3] * modifier / SoulData.Alternatives.Count - 22, Colors.Plum);
                Charts.Children.Add(indexD);

                var lineE = DrawLine(476 - item.Value[4] * modifier / SoulData.Alternatives.Count, counter + 40 + 4 * 25, Colors.Red);
                Charts.Children.Add(lineE);
                var indexE = DrawIndex(item.Value[4], counter + 40 + 4 * 25, 480 - item.Value[4] * modifier / SoulData.Alternatives.Count - 22, Colors.Red);
                Charts.Children.Add(indexE);
                
                var alternativeName = DrawLabel(item.Key, counter - 25, 480);
                alternativeName.FontFamily = new System.Windows.Media.FontFamily("Arial Black");
                Charts.Children.Add(alternativeName);


                var centredValue = (-2) * item.Value[0] + (-1) * item.Value[1] + (0) * item.Value[2] + (1) * item.Value[3] + (2) * item.Value[4];
                var value = Math.Round(Math.Pow(_specialCoef, centredValue) / Total, 4);

                RankingData.Add(new Tuple<string, double, double>(item.Key, centredValue, value));
                DrawFrame(value, counter);

                var alternativeCentredValue = DrawLabel(centredValue.ToString(), counter + 40, 500);
                alternativeCentredValue.FontFamily = new System.Windows.Media.FontFamily("Arial Black");
                alternativeCentredValue.FontSize = 16;
                alternativeCentredValue.Foreground = new SolidColorBrush(Colors.Lime);
                Charts.Children.Add(alternativeCentredValue);

                counter += 175;
            }

            DrawGridTable();

            var sum = 0.0;
            var labelB = new Label();
            foreach (var item in Charts.Children)
            {
                if (item.GetType() == new Label().GetType() && ((item as Label).Tag?.ToString() == "rankValue"))
                {
                    sum += double.Parse((item as Label).Content.ToString());
                    labelB = item as Label;
                }
            }
            if (sum == 0)
            {
                foreach (var item in Charts.Children)
                {
                    if (item.GetType() == new Label().GetType() && ((item as Label).Tag?.ToString() == "rankValue"))
                    {
                        (item as Label).Content = Math.Round(1.000 / SoulData.Alternatives.Count, 3).ToString();
                    }
                }
            }
            if (sum != 1.000)
            {
                var currentValue = double.Parse(labelB.Content.ToString());
                var newValue = currentValue + 1.000 - sum;
                labelB.Content = Math.Round(newValue, 3).ToString();
            }
        }

        private void DrawFrame(double value, int pos)
        {
            var height = int.Parse(Math.Floor(476 - (400 * value)).ToString());

            if (height == 476)
            {
                height = 461;
            }
            var lineLeft = DrawLine(height, pos + 20, Colors.Black);
            lineLeft.StrokeThickness = 3;
            Charts.Children.Add(lineLeft);

            var lineRight = DrawLine(height, pos + 160, Colors.Black);
            lineRight.StrokeThickness = 3;
            Charts.Children.Add(lineRight);

            var horizontalLine = new Line()
            {
                X1 = pos + 20,
                Y1 = height,
                X2 = pos+160,
                Y2 = height,
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 3
            };
            Canvas.SetZIndex(horizontalLine, 3);
            Charts.Children.Add(horizontalLine);

            var label = DrawLabel(Math.Round(value, 3).ToString(), pos, 480);
            label.FontSize = 14;
            label.Tag = "rankValue";
            label.Foreground = new SolidColorBrush(Colors.Black);
            label.FontFamily = new System.Windows.Media.FontFamily("Arial Black");
            label.Margin = new Thickness(pos + 80, height - 30, 0, 0);
            Canvas.SetZIndex(label, 3);
            Charts.Children.Add(label);
        }

        private Label DrawIndex(int value, int posLeft, int posTop, System.Windows.Media.Color color)
        {
            var label = new Label();
            label.Content = value;
            label.Foreground = new SolidColorBrush(color);
            label.FontSize = 12;
            label.FontWeight = FontWeights.Bold;
            Canvas.SetLeft(label, posLeft - 9);
            Canvas.SetTop(label, posTop - 3);
            return label;
        }

        private Label DrawLabel(string content, int pos, int marginTop)
        {
            var label = new Label();
            label.Content = content;
            label.Foreground = new SolidColorBrush(Colors.White);
            label.Margin = new Thickness(pos + 40, marginTop, 0, 0);
            return label;
        }

        private Line DrawLine(int height, int pos, System.Windows.Media.Color color)
        {
            var line = new Line();
            line.X1 = pos;
            line.Y1 = 476;
            line.X2 = pos;
            line.Y2 = height;
            line.StrokeThickness = 15;
            line.Stroke = new SolidColorBrush(color);
            return line;
        }

        private void ConvertDataForOneAlternative(List<string> alternatives)
        {
            DataForAlternatives = new Dictionary<string, Dictionary<int, Dictionary<string, CirclePoint>>>();
            foreach (var alternative in alternatives)
            {
                var col = new Dictionary<int, Dictionary<string, CirclePoint>>();
                foreach (var step in Data)
                {
                    if (step.Value.ContainsKey(alternative))
                    {
                        col.Add(step.Key, step.Value);
                    }
                }
                DataForAlternatives.Add(alternative, col);
            }
        }

        private void DrawCharts()
        {
            var counter = default(int);
            
            PieDataCollection<PieSegment> collection = new PieDataCollection<PieSegment>();
            _collectionList = new PieDataCollection<PieSegment>();
            PieChart pie = new PieChart()
            {
                Width = 600,
                Height = 500,
                PieWidth = 450,
                PieHeight = 450,
                Margin = new Thickness(5, 5, 5, 5),
                HorizontalAlignment = HorizontalAlignment.Left,
                Data = collection,
                PopupBrush = new SolidColorBrush(Colors.White),

            };
            pie.SetValue(Grid.ColumnProperty, 0);
            pie.SetValue(Grid.RowProperty, counter++);

            var storage = new Dictionary<string, double>();
            foreach (var step in Data)
            {
                foreach (var item in step.Value)
                {
                    if (!storage.ContainsKey(item.Key))
                    {
                        storage.Add(item.Key, item.Value.distance);
                    }
                    else
                    {
                        storage[item.Key] += item.Value.distance;
                    }
                }
            }
            var sortedStorage = storage.OrderBy(x => x.Value).Reverse();


            foreach (var item in sortedStorage)
            {
                collection.Add(new PieSegment()
                {
                    Color = new System.Windows.Media.Color()
                    {
                        A = 100,
                        R = (byte)SoulData.ColorStorage[item.Key].Item1,
                        G = (byte)SoulData.ColorStorage[item.Key].Item2,
                        B = (byte)SoulData.ColorStorage[item.Key].Item3,
                    },
                    Name = item.Key,
                    Value = item.Value,
                }
                );
            }
            pie.Data = collection;
            Charts.Children.Add(pie);
            _collectionList = collection;
        }

        private void DrawGridTable()
        {
            dataGrid.ItemsSource = from entry in RankingData orderby entry.Item2 descending select entry;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CheckBoxesControl();
            Thread.Sleep(500);
            if (PathToSaveResults != string.Empty)
            {
                SaveResults();

                double screenLeft = this.Left;
                double screenTop = this.Top;
                double screenWidth = this.Width;
                double screenHeight = this.Height;

                using (Bitmap bmp = new Bitmap((int)screenWidth,
                    (int)screenHeight))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        String filename = "TeGR" + DateTime.Now.ToString("ddmmyyyy-hhMMss") + ".png";
                        Opacity = .0;
                        g.CopyFromScreen((int)screenLeft, (int)screenTop, 0, 0, bmp.Size);
                        if (string.IsNullOrEmpty(PathToSaveResults))
                        {
                            PathToSaveResults = System.IO.Directory.GetCurrentDirectory();
                        }
                        bmp.Save($@"{PathToSaveResults}\{filename}");
                        Opacity = 1;
                    }
                }
            }
        }

        private void CheckBoxesControl()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();
            dialog.Description = "Оберіть папку для збереження результату";
            dialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            PathToSaveResults = dialog.SelectedPath;
        }

        private void SaveResults()
        {
            var time = DateTime.Now.ToString("dd-mm-yy_hh-mm-ss");

            using (StreamWriter sw = new StreamWriter(PathToSaveResults + $@"\\TeGR{time}.txt", false, Encoding.UTF8))
            {
                var line = string.Empty;
                foreach (var step in Data)
                {
                    line += $"КРОК {step.Key}: ";
                    foreach (var alternative in step.Value)
                    {
                        line += $"{alternative.Key} : {alternative.Value.distance},\t";
                    }
                    line = line.Substring(0, line.Length - 2) + ";";
                    sw.WriteLine(line);
                    line = string.Empty;
                }
            }
        }

        private void ShowDataForOneAlternative(object sender, RoutedEventArgs e)
        {
            ResultForOneAlternative window = new ResultForOneAlternative(allListsBox.SelectedItem.ToString(), DataForAlternatives[allListsBox.SelectedItem.ToString()]);
            window.Show();
        }

        private void returnToMain_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = System.Windows.MessageBox.Show("Результати поточного ранжування будуть втрачені.\nВиконати ранжування ще раз, використовуючи існуючі альтернативи?", "Увага", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (dialogResult)
            {
                case MessageBoxResult.Yes:
                    isClose = false;
                    WorkWindow.isClose = false;
                    WorkWindow.Close();
                    this.Close();
                    var alternatives = SoulData.Alternatives;
                    SoulData.Initialize();
                    SoulData.Alternatives = alternatives;
                    var window = new QuestionWindow(WindowOwner, _container);
                    window.Show();
                    break;
                case MessageBoxResult.No:
                    isClose = false;
                    WorkWindow.isClose = false;
                    WorkWindow.Close();
                    WindowOwner.isClose = false;
                    WindowOwner.Close();
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void continueWork_Click(object sender, RoutedEventArgs e)
        {
            isClose = false;
            WorkWindow.Show();
            SoulData.Storage.Add(lastRanking.Key, lastRanking.Value);
            this.Close();
        }

        private void ExitClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isClose)
            {
                var dialogResult = System.Windows.MessageBox.Show("Ви дійсно хочете вийти з програми?", "Вихід з програми", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                switch (dialogResult)
                {
                    case MessageBoxResult.Yes:
                        WindowOwner.Show();
                        //WindowOwner.Close();
                        WorkWindow.isClose = false;
                        WorkWindow.Close();
                        break;
                    case MessageBoxResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void GetFocusOfMouse(object sender, MouseEventArgs e)
        {
            if (sender.GetType().Equals(new ComboBox().GetType()))
            {
                infoBox.Text = Strings.selectorCombobox;
            }
            else
            {
                var text = (sender as ContentControl).Content.ToString();
                switch (text)
                {
                    case "Нова задача":
                        infoBox.Text = Strings.returnToMain;
                        break;
                    case "Продовжити ранжування":
                        infoBox.Text = Strings.continueWork;
                        break;
                    case "Переглянути переваги":
                        infoBox.Text = Strings.showAlternative;
                        break;
                    case "Зберегти результати":
                        infoBox.Text = Strings.saveResults;
                        break;
                    default:
                        infoBox.Text = Strings.startData;
                        break;
                }
            }
        }

        private void LostFocusOfMouse(object sender, MouseEventArgs e)
        {
            infoBox.Text = Strings.startData;
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            About window = new About();
            window.Show();
        }

        private void LoadedActions(object sender, RoutedEventArgs e)
        {
            dataGrid.Columns[0].Header = "Назва альтернативи";
            dataGrid.Columns[1].Header = "Центроване ранжування";
            dataGrid.Columns[2].Header = "Нормоване ранжування";

            foreach (var item in dataGrid.Columns)
            {
                item.CanUserSort = false;
            }
            
            var styleHeader = new Style(typeof(GridViewColumnHeader));
            styleHeader.Setters.Add(new Setter(GridViewColumnHeader.FontFamilyProperty, new System.Windows.Media.FontFamily("Arial")));
            styleHeader.Setters.Add(new Setter(GridViewColumnHeader.ForegroundProperty, new SolidColorBrush(Colors.Black)));
            styleHeader.Setters.Add(new Setter(GridViewColumnHeader.FontSizeProperty, 20.0));
            styleHeader.Setters.Add(new Setter(GridViewColumnHeader.FontWeightProperty, FontWeights.Bold));
            styleHeader.Setters.Add(new Setter(GridViewColumnHeader.HorizontalAlignmentProperty, HorizontalAlignment.Center));

            Resources.Add(typeof(GridViewColumnHeader), styleHeader);


            var styleCell = new Style(typeof(DataGridCell));
            styleCell.Setters.Add(new Setter(DataGridCell.FontSizeProperty, 12.0));
            styleCell.Setters.Add(new Setter(DataGridCell.FontWeightProperty, FontWeights.Bold));
            styleCell.Setters.Add(new Setter(DataGridCell.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));

            Resources.Add(typeof(DataGridCell), styleCell);


            //var styleColumn = new Style(typeof(DataGridColumn));
            //styleColumn.Setters.Add(new Setter(DataGridColumn.CanUserSortProperty, false));
            //styleColumn.Setters.Add(new Setter(DataGridColumn.CanUserResizeProperty, false));
            //styleColumn.Setters.Add(new Setter(DataGridColumn.IsReadOnlyProperty, true));

            //Resources.Add(typeof(DataGridColumn), styleColumn);
        }

        private void openTable_Click(object sender, RoutedEventArgs e)
        {
            switch ((int?)dataGrid.Opacity)
            {
                case 0:
                    openTable.Content = "Закрити таблицю";
                    dataGrid.Opacity = 1;
                    break;
                case 1:
                    openTable.Content = "Відкрити таблицю";
                    dataGrid.Opacity = 0;
                    break;
            }
        }
    }
}
