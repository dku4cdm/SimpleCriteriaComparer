using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleCriteriaComparer
{
    /// <summary>
    /// Логика взаимодействия для QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        internal bool isClose { get; set; }

        private Container _container { get; set; }

        private QuestionSource Source { get; set; }

        private Tuple<string, string, int> ConflictItems { get; set; }
        
        private MainWindow MainWindow { get; set; }

        private List<Label> Alternatives { get; set; }

        private List<Rectangle> ItemsForMoving { get; set; }

        private IDrawHelper _drawHelper { get; set; }

        public QuestionWindow()
        {
            InitializeComponent();
        }

        public QuestionWindow(MainWindow mainWindow, Container container)
        {
            InitializeComponent();
            _container = container;
            _drawHelper = _container.GetInstance<IDrawHelper>();
            isClose = true;
            SoulData.CurrentRanking = 1;
            SetInfoForUser();
            _drawHelper.DrawScalesForCircle(drawingArea.Children);
            SetTotalRankings(SoulData.Alternatives.Count);
            MainWindow = mainWindow;
            Alternatives = new List<Label>();
            ItemsForMoving = new List<Rectangle>();
            Source = new QuestionSource(SoulData.Alternatives.Count);
            UpdateAlternatives(SoulData.Alternatives);
            var startAlternatives = ChooseAlternativesForComparison(SoulData.CurrentRanking);
            UpdateStorage(startAlternatives);
            UpdateItemsForMoving(startAlternatives);
            _drawHelper.DrawCircleGrid(drawingArea);
            _drawHelper.HideCircleGrid(drawingArea.Children);
            _drawHelper.DrawNumericScalesForCircle(body);
            ChangeSectorsOnCircle();
            ChangeColorForGradation();
            gradationCombobox.ItemsSource = new object[6] { 5, 10, 20, 50, 100, 500 };
            this.Title += $"{SoulData.CurrentRanking}/{SoulData.TotalRankings}";
            progressInfo.Text = $"{SoulData.CurrentRanking}/{SoulData.TotalRankings}";
            startInfo.Content = $"Перетягніть кружечки-альтернативи на круг переваг:";
        }

        private void SetInfoForUser()
        {
            infoBox.Text = "1. Чим більш важливою є альтернатива, тим ближче до центра круга переваг потрібно розташовувати відповідний кружечок.\n\n" +
                        "2. Перевага однієї альтернативи над іншою виражається у відношенні відстаней від центра круга до відповідних кружечків.\n\n" +
                        "3. У разі рівнозначності альтернатив встановіть відповідні кружечки в одну градацію."; 
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UsedAllMovingItems() && isConflict.Text == "Ні")
            {
                UpdateTitleWithStep(true);
                if(!isEnd())
                {
                    var selectedAlternatives = ChooseAlternativesForComparison(SoulData.CurrentRanking);
                    UpdateCanvas(selectedAlternatives);
                    UpdateStorage(selectedAlternatives);
                    progressInfo.Text = $"{SoulData.CurrentRanking}/{SoulData.TotalRankings}";
                    if (SoulData.CurrentRanking >= SoulData.TotalRankings)
                    {
                        (sender as Button).Content = "Продовжити ранжування";
                    }
                    else
                    {
                        (sender as Button).Content = "Наступне ранжування";
                    }
                }
            }
            else if (isConflict.Text == "Так")
            {
                MessageBox.Show($"Виявлено суперечливість між {ConflictItems.Item1} та {ConflictItems.Item2} у {ConflictItems.Item3}/{SoulData.TotalRankings}-ому та поточному ранжуванні.", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        
        private void UpdateConflictStorage(int step, string name)
        {
            foreach (var item in  SoulData.Storage[step])
            {
                var hasConflict = ContainsRelatives(name, item.Key, true);
                var hasConflictV2 = ContainsRelatives(name, item.Key, false);
                if (SoulData.Storage[step][name].distance > SoulData.Storage[step][item.Key].distance && SoulData.Storage[step][item.Key].distance != 0 && hasConflict.Item1)
                {
                    ConflictItems = new Tuple<string, string, int>(name, item.Key, hasConflict.Item2);
                    isConflict.Text = "Так";
                    isConflict.FontSize = 15;
                    isConflict.Foreground = new SolidColorBrush(Colors.Crimson);
                    return;
                }
                else if (SoulData.Storage[step][name].distance < SoulData.Storage[step][item.Key].distance && SoulData.Storage[step][item.Key].distance != 0 && hasConflictV2.Item1)
                {
                    ConflictItems = new Tuple<string, string, int>(name, item.Key, hasConflictV2.Item2);
                    isConflict.Text = "Так";
                    isConflict.FontSize = 15;
                    isConflict.Foreground = new SolidColorBrush(Colors.Crimson);
                    return;
                }
                else
                {
                    isConflict.Text = "Ні";
                    isConflict.FontSize = 13;
                    isConflict.Foreground = new SolidColorBrush(Colors.White);
                }
            }
        }

        private Tuple<bool, int> ContainsRelatives(string firstItem, string secondItem, bool more)
        {
            for (int step = 1; step < SoulData.CurrentRanking; step++)
            {
                foreach (var item in SoulData.Storage[step])
                {
                    if (SoulData.Storage[step].ContainsKey(firstItem) && SoulData.Storage[step].ContainsKey(secondItem))
                    {
                        if (more)
                        {
                            if (SoulData.Storage[step][firstItem].distance < SoulData.Storage[step][secondItem].distance)
                            {
                                return new Tuple<bool, int>(true, step);
                            }
                        }
                        else
                        {
                            if (SoulData.Storage[step][firstItem].distance > SoulData.Storage[step][secondItem].distance)
                            {
                                return new Tuple<bool, int>(true, step);
                            }
                        }
                    }
                }
            }
            return new Tuple<bool, int>(false, 0);
        }

        private void UpdateTitleWithStep(bool isToNextStep)
        {
            if (isToNextStep)
            {
                this.Title = $"Ранжування {SoulData.CurrentRanking + 1}/{SoulData.TotalRankings}";
                SoulData.CurrentRanking++;
            }
            else
            {
                this.Title = $"Ранжування {SoulData.CurrentRanking - 1}/{SoulData.TotalRankings}";
                SoulData.CurrentRanking--;
            }
        }

        private bool isEnd()
        {
            if (SoulData.CurrentRanking > SoulData.TotalRankings)
            {
                MessageBox.Show("Ранжування завершене", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
                MainWindow.BuildResult(this, "true");
                return true;
            }
            return false;
        }
        
        private void previousStepBtn_Click(object sender, RoutedEventArgs e)
        {
            nextBtn.Content = "Наступне ранжування";
            SoulData.Storage.Remove(SoulData.CurrentRanking);
            UpdateTitleWithStep(false);
            var flag = false;
            if (SoulData.CurrentRanking == 0)
            {
                flag = true;
                this.Title = this.Title.Replace("0", "1");
                SoulData.CurrentRanking = 1;
            }
            var alterantives = ChooseAlternativesForComparison(SoulData.CurrentRanking);
            UpdateCanvas(alterantives);
            if (flag)
            {
                UpdateStorage(alterantives);
            }
            progressInfo.Text = $"{SoulData.CurrentRanking}/{SoulData.TotalRankings}";
        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            //isClose = false;
            this.Close();
        }

        private void SetTotalRankings(int count)
        {
            switch (count)
            {
                case 3:
                    SoulData.TotalRankings = 1;
                    break;
                case 4:
                    SoulData.TotalRankings = 4;
                    break;
                case 5:
                    SoulData.TotalRankings = 10;
                    break;
                case 6:
                    SoulData.TotalRankings = 20;
                    break;
                case 7:
                    SoulData.TotalRankings = 35;
                    break;
                case 8:
                    SoulData.TotalRankings = 56;
                    break;
                case 9:
                    SoulData.TotalRankings = 84;
                    break;
                default:
                    break;
            }
        }
        
        private List<string> ChooseAlternativesForComparison(int step)
        {
            //TODO: logic for steps
            var indexes = Source.GetIndexOfAlternatives(step);
            var alternatives = new List<Label>();
            for (int index = 0; index < indexes.Count(); index++)
            {
                alternatives.Add(Alternatives[indexes[index]]);
            }
            DrawAlternatives(alternatives);
            return alternatives.Select(x => x.Content as string).ToList();
        }

        private void UpdateStorage(List<string> alternatives)
        {
            var containerAlternatives = new Dictionary<string, CirclePoint>();

            alternatives.ForEach(item =>
            {
                containerAlternatives.Add(item, new CirclePoint()
                {
                    distance = 0,
                    x = 0,
                    y = 0,
                });
                
            });
            SoulData.Storage.Add(SoulData.CurrentRanking, containerAlternatives);
        }

        private void DrawAlternatives(List<Label> alternatives)
        {
            alternativesPanel.Children.Clear();

            for (int index = 0; index < alternatives.Count; index++)
            {
                alternativesPanel.Children.Add(alternatives[index]);
            }
        }
        
        private void UpdateAlternatives(List<string> alternatives)
        {
            for (int index = 0; index < alternatives.Count; index++)
            {
                var label = _drawHelper.DrawLabel(index, alternatives[index]);

                Alternatives.Add(label);
            }
        }
        
        private void UpdateItemsForMoving(List<string> selectedAlternatives)
        {
            for (int iterator = 0; iterator < selectedAlternatives.Count; iterator++)
            {
                var item = _drawHelper.DrawItemForMoving(iterator, selectedAlternatives[iterator]);
                var position = _drawHelper.DrawTextBlock(iterator + 1);

                Grid grid = new Grid();
                grid.Children.Add(item);
                grid.Children.Add(position);
                grid.SetValue(Canvas.LeftProperty, -20.0);
                grid.SetValue(Canvas.TopProperty, iterator * 40.0);
                grid.Tag = new MovingItem();
                grid.ToolTip = item.Tag;
                grid.SetValue(Canvas.ZIndexProperty, 3);
                grid.MouseLeftButtonDown += new MouseButtonEventHandler(item_MouseDown);
                grid.MouseMove += new MouseEventHandler(item_MouseMove);
                grid.MouseUp += new MouseButtonEventHandler(item_MouseUp);

                drawingArea.Children.Add(grid);
            }
        }

        private void item_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as Grid;
            var properties = item.Tag as MovingItem;
            properties.drag = true;
            Cursor = Cursors.Hand;
            properties.startPt = e.GetPosition(drawingArea);
            properties.width = (int)item.Width;
            properties.height = (int)item.Height;
            properties.lastLocation = new Point(Canvas.GetLeft(item), Canvas.GetTop(item));
            Mouse.Capture((IInputElement)sender);
        }

        private void ShowConflictMessage()
        {
            if (isConflict.Text == "Так")
            {
                MessageBox.Show($"Виявлено суперечливість між {ConflictItems.Item1} та {ConflictItems.Item2}", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void item_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var item = sender as Grid;
                var properties = item.Tag as MovingItem;
                if (properties.drag)
                {
                    var newX = (e.GetPosition(drawingArea).X);
                    var newY = (e.GetPosition(drawingArea).Y);
                    Point offset = new Point((properties.startPt.X - properties.lastLocation.X), (properties.startPt.Y - properties.lastLocation.Y));
                    properties.CanvasTop = newY - offset.Y;
                    properties.CanvasLeft = newX - offset.X;

                    var coordX = (newX - drawingArea.Width) * (SoulData.CurrentGradation / drawingArea.Width);
                    var coordY = -1 * (newY - drawingArea.Width) * (SoulData.CurrentGradation / drawingArea.Width);
                    var distance = Math.Ceiling(SoulData.CurrentGradation - CalculateDistance(coordX, coordY));

                    if ((((properties.CanvasTop + 13 > drawingArea.Height) || (properties.CanvasLeft + 13 > drawingArea.Width) || (properties.CanvasTop < -10) || (properties.CanvasLeft < -10) || (distance <= 0))))
                    {
                        return;
                    }
                    item.SetValue(Canvas.TopProperty, properties.CanvasTop);
                    item.SetValue(Canvas.LeftProperty, properties.CanvasLeft);
                    
                    curCoord.Text = Math.Ceiling(distance).ToString();
                    SoulData.Storage[SoulData.CurrentRanking][item.ToolTip.ToString()].x = coordX;
                    SoulData.Storage[SoulData.CurrentRanking][item.ToolTip.ToString()].y = coordY;
                    SoulData.Storage[SoulData.CurrentRanking][item.ToolTip.ToString()].distance = distance;
                    UpdateConflictStorage(SoulData.CurrentRanking, item.ToolTip.ToString());
                    
                    if (Math.Abs(distance - SoulData.Storage[SoulData.CurrentRanking][item.ToolTip.ToString()].distance) >= 0.5)
                    {
                        SoulData.Storage[SoulData.CurrentRanking][item.ToolTip.ToString()].distance = distance;
                        curCoord.Text = Math.Round(distance).ToString();
                    }
                    item.Children[0].Opacity = (distance / SoulData.CurrentGradation) + 0.2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private Tuple<bool, string> UpdateEqualityOfAlternatives(string name)
        {
            foreach (var item in SoulData.Storage[SoulData.CurrentRanking])
            {
                if (Math.Abs(item.Value.distance - SoulData.Storage[SoulData.CurrentRanking][name].distance) < 0.5 && item.Key != name && item.Value.x != 0 && item.Value.y != 0) 
                {
                    SoulData.Storage[SoulData.CurrentRanking][name].distance = item.Value.distance;
                    curCoord.Text = Math.Round(item.Value.distance).ToString();
                    return new Tuple<bool, string>(true, item.Key);
                }
            }
            return new Tuple<bool, string>(false, string.Empty);
        }
        private void item_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var item = sender as Grid;
            var properties = item.Tag as MovingItem;
            properties.drag = false;
            Cursor = Cursors.Arrow;
            Mouse.Capture(null);
            ShowConflictMessage();
        }

        private double CalculateDistance(double x, double y)
        {
            var distanse = Math.Sqrt(x * x + y * y);
            return distanse;
        }
        
        private void UpdateCanvas(List<string> selectedAlternatives)
        {
            drawingArea.Children.Clear();
            _drawHelper.DrawCircleGrid(drawingArea);
            _drawHelper.ShowCircleGrid(drawingArea.Children);
            _drawHelper.DrawScalesForCircle(drawingArea.Children);
            UpdateItemsForMoving(selectedAlternatives);
        }

        private bool UsedAllMovingItems()
        {
            foreach (var item in drawingArea.Children)
            {
                if (item.GetType() == new Grid().GetType())
                {
                    var alternative = item as Grid;
                    if (double.Parse(alternative.GetValue(Canvas.LeftProperty).ToString()) < -20)
                    {
                        MessageBox.Show("Встановіть усі елементи в область ранжування", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        private void ChangeColorForGradation()
        {

            GradientStopCollection col = new GradientStopCollection();
            col.Add(new GradientStop(new Color() { A = 100, R = 255, G = 120, B = 120 }, 1));
            col.Add(new GradientStop(new Color() { A = 100, R = 255, G = 105, B = 105 }, 0.95));
            col.Add(new GradientStop(new Color() { A = 100, R = 255, G = 90, B = 90 }, 0.90));
            col.Add(new GradientStop(new Color() { A = 100, R = 255, G = 75, B = 75 }, 0.85));
            col.Add(new GradientStop(new Color() { A = 100, R = 255, G = 60, B = 60 }, 0.80));
            col.Add(new GradientStop(new Color() { A = 100, R = 255, G = 45, B = 45 }, 0.75));
            col.Add(new GradientStop(new Color() { A = 100, R = 255, G = 30, B = 30 }, 0.70));
            col.Add(new GradientStop(new Color() { A = 100, R = 255, G = 15, B = 15 }, 0.65));
            col.Add(new GradientStop(new Color() { A = 100, R = 255, G = 0, B = 0 }, 0.60));
            col.Add(new GradientStop(new Color() { A = 100, R = 245, G = 0, B = 0 }, 0.55));
            col.Add(new GradientStop(new Color() { A = 100, R = 235, G = 0, B = 0 }, 0.50));
            col.Add(new GradientStop(new Color() { A = 100, R = 225, G = 0, B = 0 }, 0.45));
            col.Add(new GradientStop(new Color() { A = 100, R = 215, G = 0, B = 0 }, 0.40));
            col.Add(new GradientStop(new Color() { A = 100, R = 205, G = 0, B = 0 }, 0.35));
            col.Add(new GradientStop(new Color() { A = 100, R = 195, G = 0, B = 0 }, 0.30));
            col.Add(new GradientStop(new Color() { A = 100, R = 185, G = 0, B = 0 }, 0.25));
            col.Add(new GradientStop(new Color() { A = 100, R = 175, G = 0, B = 0 }, 0.20));
            col.Add(new GradientStop(new Color() { A = 100, R = 165, G = 0, B = 0 }, 0.15));
            col.Add(new GradientStop(new Color() { A = 100, R = 155, G = 0, B = 0 }, 0.10));
            col.Add(new GradientStop(new Color() { A = 100, R = 145, G = 0, B = 0 }, 0.05));

            GradientStopCollection bigCol = new GradientStopCollection();
            bigCol.Add(new GradientStop(new Color() { A = 100, R = 178, G = 0, B = 0 }, 0));
            bigCol.Add(new GradientStop(new Color() { A = 100, R = 251, G = 171, B = 171 }, 1));
            bigCol.Add(new GradientStop(new Color() { A = 100, R = 226, G = 10, B = 10 }, 0.233));
            bigCol.Add(new GradientStop(new Color() { A = 100, R = 220, G = 33, B = 33 }, 0.44));
            bigCol.Add(new GradientStop(new Color() { A = 100, R = 216, G = 83, B = 83 }, 0.61));
            bigCol.Add(new GradientStop(new Color() { A = 100, R = 209, G = 7, B = 7 }, 0.117));
            bigCol.Add(new GradientStop(new Color() { A = 100, R = 218, G = 25, B = 25 }, 0.363));
            bigCol.Add(new GradientStop(new Color() { A = 100, R = 240, G = 118, B = 118 }, 0.76));
            switch (SoulData.CurrentGradation)
            {
                case 5:
                    mainCircle.Fill = new RadialGradientBrush(col.Where(color => col.IndexOf(color) % 4 == 0).ToGradientStopCollection());
                    break;
                case 10:
                    mainCircle.Fill = new RadialGradientBrush(col.Where(color => col.IndexOf(color) % 2 == 0).ToGradientStopCollection());
                    break;
                case 20:
                    mainCircle.Fill = new RadialGradientBrush(col);
                    break;
                default:
                    mainCircle.Fill = new RadialGradientBrush(bigCol);
                    break;
            }
        }
        
        private void CheckedShowAddInfo(object sender, RoutedEventArgs e)
        {
            AdditionalInfo.Opacity = 0.6;
        }

        private void CheckedShowCircleGrid(object sender, RoutedEventArgs e)
        {
            _drawHelper.ShowCircleGrid(drawingArea.Children);
        }

        private void UnCheckedShowCircleGrid(object sender, RoutedEventArgs e)
        {
            _drawHelper.HideCircleGrid(drawingArea.Children);
        }

        private void UnCheckedShowAddInfo(object sender, RoutedEventArgs e)
        {
            AdditionalInfo.Opacity = 0;
        }

        private void stopBtn_Click(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (SoulData.TotalRankings >= SoulData.CurrentRanking)
            {
                if (isClose)
                {
                    var content = $"";
                    if (SoulData.TotalRankings - SoulData.CurrentRanking == 0)
                    {
                        content = $"Для максимальної надійності результатів, рекомендується завершити поточне ранжування.\nПереглянути проміжні результати?";
                    }
                    else if ((SoulData.TotalRankings - SoulData.CurrentRanking + 1) % 10 < 5)
                    {
                        content = $"Для максимальної надійності результатів, рекомендується провести ще {SoulData.TotalRankings - SoulData.CurrentRanking + 1} ранжування.\nПереглянути проміжні результати?";
                    }
                    else
                    {
                        content = $"Для максимальної надійності результатів, рекомендується провести ще {SoulData.TotalRankings - SoulData.CurrentRanking + 1} ранжувань.\nПереглянути проміжні результати?";
                    }

                    var resultDialog = MessageBox.Show(content, "Попередження", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.DefaultDesktopOnly);

                    switch (resultDialog)
                    {
                        case MessageBoxResult.Yes:
                            MainWindow.BuildResult(this, (SoulData.TotalRankings - SoulData.CurrentRanking + 1).ToString());
                            e.Cancel = true;
                            this.Hide();
                            break;
                        case MessageBoxResult.No:
                            e.Cancel = true;
                            break;
                    }
                }
                else
                {
                    //MainWindow.BuildResult(this, (SoulData.TotalRankings - SoulData.CurrentRanking + 1).ToString());
                    //e.Cancel = true;
                    //this.Hide();
                    //isClose = true;
                }
            }
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            About window = new About();
            window.Show();
        }

        private void ChangedGradation(object sender, SelectionChangedEventArgs e)
        {
            var newGradation = int.Parse(gradationCombobox.SelectedItem.ToString());
            var modificator = newGradation / (SoulData.CurrentGradation - 0.0001);
            curCoord.Text = "0";
            curCoord.Text = (Math.Floor(int.Parse(curCoord.Text) * modificator)).ToString();
            ChangeValuesOfAlternatives(modificator);
            SoulData.CurrentGradation = newGradation;
            ChangeColorForGradation();
            ChangeSectorsOnCircle();
            _drawHelper.DrawScalesForCircle(drawingArea.Children);
            _drawHelper.DrawNumericScalesForCircle(body);
            _drawHelper.DrawCircleGrid(drawingArea);
            _drawHelper.HideCircleGrid(drawingArea.Children);
        }
        
        private void ChangeSectorsOnCircle()
        {
            foreach (var item in body.Children)
            {
                switch (SoulData.CurrentGradation)
                {
                    case 5:
                        if (item.GetType() == new Ellipse().GetType() && 
                            ((item as Ellipse).Tag?.ToString() == "10" || (item as Ellipse).Tag?.ToString() == "20"))
                                (item as Ellipse).Opacity = 0;
                        if (item.GetType() == new Ellipse().GetType() &&
                            (item as Ellipse).Tag?.ToString() == "5")
                                (item as Ellipse).Opacity = 1;
                        break;
                    case 10:
                        if (item.GetType() == new Ellipse().GetType() &&
                            ((item as Ellipse).Tag?.ToString() == "5" || (item as Ellipse).Tag?.ToString() == "10"))
                            (item as Ellipse).Opacity = 1;
                        if (item.GetType() == new Ellipse().GetType() &&
                            (item as Ellipse).Tag?.ToString() == "20")
                            (item as Ellipse).Opacity = 0;
                        break;
                    case 20:
                        if (item.GetType() == new Ellipse().GetType())
                            (item as Ellipse).Opacity = 1;
                        break;
                    default:
                        if (item.GetType() == new Ellipse().GetType() &&
                            ((item as Ellipse).Tag?.ToString() == "5" || (item as Ellipse).Tag?.ToString() == "10" 
                            || (item as Ellipse).Tag?.ToString() == "20"))
                            (item as Ellipse).Opacity = 0;
                        break;
                }
            }
        }

        private void ChangeValuesOfAlternatives(double modificator)
        {
            foreach (var item in SoulData.Storage[SoulData.CurrentRanking])
            {
                item.Value.distance *= modificator;
            }
        }
    }
}
