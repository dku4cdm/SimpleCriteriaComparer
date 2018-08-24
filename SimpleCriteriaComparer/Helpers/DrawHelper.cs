using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleCriteriaComparer
{
    public class DrawHelper : IDrawHelper
    {
        public Line DrawLine(int x1, int y1, int x2, int y2)
        {
            var line = new Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.StrokeThickness = 4;

            return line;
        }

        public TextBox DrawTextBox()
        {
            TextBox textBox = new TextBox();
            textBox.HorizontalAlignment = HorizontalAlignment.Left;
            textBox.Height = 40;
            textBox.Width = 320;
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.Text = $"Альтернатива";
            textBox.VerticalAlignment = VerticalAlignment.Top;
            textBox.Foreground = new SolidColorBrush(Colors.White);
            textBox.Background = new SolidColorBrush(new Color() { A = 100, R = 62, G = 60, B = 60 });
            textBox.BorderBrush = new SolidColorBrush(new Color() { A = 100, R = 62, G = 60, B = 60 });
            textBox.FontFamily = new FontFamily("Arial Black");
            textBox.FontSize = 18;

            return textBox;
        }
        
        public void UpdateNamesForAlternatives(UIElementCollection collection)
        {
            for (int index = 0; index < collection.Count; index++)
            {
                var textBox = collection[index] as TextBox;
                textBox.Text.Trim();
                if (textBox.Text.Contains("Альтернатива"))
                {
                    textBox.Text = $"Альтернатива {index + 1}";
                }
                if (textBox.Text.Length >= 16)
                {
                    textBox.Text = textBox.Text.Substring(0, 16) + "...";
                }
            }
        }

        public Label DrawNumericLabel(string content, int marginLeft, int marginTop)
        {
            var label = new Label();
            label.FontSize = 14;
            label.FontFamily = new FontFamily("Arial Black");
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.Height = 29;
            label.Margin = new Thickness(marginLeft, marginTop, 0, 0);
            label.VerticalAlignment = VerticalAlignment.Top;
            label.Width = 40;
            label.Tag = "numericLabel";
            label.Foreground = new SolidColorBrush(Colors.White);
            label.Content = content;

            return label;
        }

        public void DrawNumericScalesForCircle(Grid grid)
        {
            foreach (var item in grid.Children)
            {
                if (item.GetType() == new Label().GetType() && (item as Label).Tag?.ToString() == "numericLabel")
                {
                    (item as Label).Opacity = 0;
                }
            }

            var label = new Label();

            switch (SoulData.CurrentGradation)
            {
                case 5:
                    for (int index = 1; index <= 5; index++)
                    {
                        label = DrawNumericLabel(index.ToString(), 292 + (index - 1) * 95, 546);
                        grid.Children.Add(label);

                        label = DrawNumericLabel(index.ToString(), 732, 95 + (index - 1) * 95);
                        grid.Children.Add(label);
                    }
                    break;
                case 10:
                    for (int index = 1; index <= 10; index++)
                    {
                        label = DrawNumericLabel(index.ToString(), 250 + (index - 1) * 49, 546);
                        grid.Children.Add(label);

                        label = DrawNumericLabel(index.ToString(), 732, 65 + (index - 1) * 49);
                        grid.Children.Add(label);
                    }
                    break;
                case 20:
                    for (int index = 1; index <= 3; index++)
                    {
                        label = DrawNumericLabel((index * 5).ToString(), 350 + (index - 1) * 115, 546);
                        grid.Children.Add(label);

                        label = DrawNumericLabel((index * 5).ToString(), 732, 160 + (index - 1) * 115);
                        grid.Children.Add(label);
                    }

                    label = DrawNumericLabel("1", 250, 546);
                    grid.Children.Add(label);

                    label = DrawNumericLabel("1", 732, 55);
                    grid.Children.Add(label);

                    label = DrawNumericLabel("20", 732, 546);
                    grid.Children.Add(label);
                    break;
                case 50:
                    for (int index = 1; index <= 4; index++)
                    {
                        label = DrawNumericLabel((index * 10).ToString(), 320 + (index - 1) * 90, 546);
                        grid.Children.Add(label);

                        label = DrawNumericLabel((index * 10).ToString(), 732, 135 + (index - 1) * 105);
                        grid.Children.Add(label);
                    }

                    label = DrawNumericLabel("1", 240, 546);
                    grid.Children.Add(label);

                    label = DrawNumericLabel("1", 732, 55);
                    grid.Children.Add(label);

                    label = DrawNumericLabel("50", 732, 546);
                    grid.Children.Add(label);
                    break;
                case 100:
                    for (int index = 1; index <= 3; index++)
                    {
                        label = DrawNumericLabel((index * 25).ToString(), 350 + (index - 1) * 110, 546);
                        grid.Children.Add(label);

                        label = DrawNumericLabel((index * 25).ToString(), 732, 160 + (index - 1) * 115);
                        grid.Children.Add(label);
                    }

                    label = DrawNumericLabel("1", 240, 546);
                    grid.Children.Add(label);

                    label = DrawNumericLabel("1", 732, 55);
                    grid.Children.Add(label);

                    label = DrawNumericLabel("100", 732, 546);
                    grid.Children.Add(label);
                    break;
                default:
                    for (int index = 1; index <= 4; index++)
                    {
                        label = DrawNumericLabel((index * 100).ToString(), 320 + (index - 1) * 90, 546);
                        grid.Children.Add(label);

                        label = DrawNumericLabel((index * 100).ToString(), 732, 125 + (index - 1) * 95);
                        grid.Children.Add(label);
                    }
                    label = DrawNumericLabel("1", 240, 546);
                    grid.Children.Add(label);

                    label = DrawNumericLabel("1", 732, 55);
                    grid.Children.Add(label);

                    label = DrawNumericLabel("500", 732, 546);
                    grid.Children.Add(label);
                    break;
            }
        }

        public Line DrawLine(double x1, double y1, double x2, double y2)
        {
            var myLine = new Line();
            myLine.Stroke = Brushes.Black;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 1;
            myLine.X1 = x1;
            myLine.Y1 = y1;
            myLine.X2 = x2;
            myLine.Y2 = y2;
            myLine.Tag = "circleGrid";

            return myLine;
        }

        public void HideCircleGrid(UIElementCollection collection)
        {
            for (int index = 0; index < collection.Count; index++)
            {
                var element = collection[index];

                if (element.GetType() == new Line().GetType())
                {
                    var line = element as Line;

                    if (line.Tag.ToString().Equals("circleGrid"))
                    {
                        line.Opacity = 0;
                    }
                }
            }
        }

        public void ShowCircleGrid(UIElementCollection collection)
        {
            for (int index = 0; index < collection.Count; index++)
            {
                var element = collection[index];

                if (element.GetType() == new Line().GetType())
                {
                    var line = element as Line;

                    if (line.Tag.ToString().Equals("circleGrid"))
                    {
                        line.Opacity = 0.5;
                    }
                }
            }
        }

        public void DrawCircleGrid(Canvas area)
        {
            if (SoulData.CurrentGradation == 50)
            {
                for (int index = 0; index <= area.Width; index += 480 / SoulData.CurrentGradation)
                {
                    var horLine = DrawLine(0, index, 480, index);
                    horLine.Tag = "circleGrid";
                    horLine.SetValue(Canvas.ZIndexProperty, -2);
                    area.Children.Add(horLine);

                    var verLine = DrawLine(index, 0, index, 480);
                    verLine.Tag = "circleGrid";
                    verLine.SetValue(Canvas.ZIndexProperty, -2);
                    area.Children.Add(verLine);
                }
            }
        }

        public void DrawScalesForCircle(UIElementCollection collection)
        {
            var listForClear = new List<UIElement>();
            foreach (var item in collection)
            {
                if (item.GetType() == new Line().GetType() && ((item as Line).Tag.ToString() == "scale" || (item as Line).Tag.ToString() == "circleGrid"))
                {
                    listForClear.Add(item as UIElement);
                }
            }
            listForClear.ForEach(item =>
            {
                collection.Remove(item);
            });
            var verticalLine = DrawLine(480, 0, 480, 480);
            verticalLine.Tag = "scale";
            collection.Add(verticalLine);

            var horizontalLine = DrawLine(0, 480, 480, 480);
            horizontalLine.Tag = "scale";
            collection.Add(horizontalLine);
            if (SoulData.CurrentGradation < 100)
            {
                for (double index = 0; index <= 480; index += 480 / SoulData.CurrentGradation)
                {
                    var horLine = DrawLine(475, index, 480, index);
                    horLine.Tag = "scale";
                    collection.Add(horLine);

                    var verLine = DrawLine(index, 475, index, 480);
                    verLine.Tag = "scale";
                    collection.Add(verLine);
                }
            }
        }

        public Rectangle DrawItemForMoving(double position, string name)
        {
            var item = new Rectangle();
            item.Tag = name;
            item.Name = $"item{position.ToString().Replace(".", "")}";
            item.Stroke = new SolidColorBrush(Colors.LightBlue);
            item.Fill = new SolidColorBrush(Colors.White);
            item.Width = 30;
            item.Height = 30;
            item.SetValue(Canvas.LeftProperty, -20.0);
            item.SetValue(Canvas.TopProperty, position * 40);
            item.RadiusX = 15;
            item.RadiusY = 15;
            item.SetValue(Canvas.ZIndexProperty, 3);

            return item;
        }

        public Label DrawLabel(int id, string content)
        {
            Label label = new Label();
            label.Name = $"label{id}";
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.VerticalAlignment = VerticalAlignment.Top;
            label.Height = 40;
            label.Width = 290;
            label.Foreground = new SolidColorBrush(Colors.White);
            label.Content = content;
            label.FontFamily = new FontFamily("Arial");
            label.FontSize = 16;
            return label;
        }
        
        public TextBlock DrawTextBlock(int id)
        {
            var textBlock = new TextBlock();
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.FontWeight = FontWeights.Bold;
            textBlock.FontSize = 16;
            textBlock.SetValue(Canvas.ZIndexProperty, 3);
            textBlock.Text = id.ToString();

            return textBlock;
        }
    }
}
