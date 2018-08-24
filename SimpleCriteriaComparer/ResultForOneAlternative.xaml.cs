using PieControls;
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

namespace SimpleCriteriaComparer
{
    /// <summary>
    /// Логика взаимодействия для ResultForOneAlternative.xaml
    /// </summary>
    public partial class ResultForOneAlternative : Window
    {
        private List<PieDataCollection<PieSegment>> _collectionList = new List<PieDataCollection<PieSegment>>();

        public ResultForOneAlternative()
        {
            InitializeComponent();
        }

        public ResultForOneAlternative(string alternative, Dictionary<int, Dictionary<string, CirclePoint>> data)
        {
            InitializeComponent();
            this.Title = alternative;
            BuildBody(data);
        }

        private void BuildBody(Dictionary<int, Dictionary<string, CirclePoint>> data)
        {
            var counter = default(int);

            foreach (var step in data)
            {
                PieDataCollection<PieSegment> collection = new PieDataCollection<PieSegment>();
                collection.CollectionName = $"Ранжування {step.Key}";
                bool flag = false;

                foreach (var element in step.Value)
                {
                    var name = string.Empty;

                    if (element.Key.Length >= 15)
                    {
                        name = element.Key.Substring(0, 15) + "...";
                    }
                    else
                    {
                        name = element.Key;
                    }

                    if (element.Key == this.Title)
                    {
                        collection.Add(new PieSegment()
                        {
                            Color = Colors.Orange,
                            Name = name,
                            Value = element.Value.distance,
                        });
                    }
                    else
                    {
                        if (flag == true)
                        {
                            collection.Add(new PieSegment()
                            {
                                Color = Colors.Violet,
                                Name = name,
                                Value = element.Value.distance,
                            });
                        }
                        else
                        {
                            collection.Add(new PieSegment()
                            {
                                Color = Colors.DarkViolet,
                                Name = name,
                                Value = element.Value.distance,
                            });
                        }
                        flag = true;
                    }
                }
                _collectionList.Add(collection);
                PieChart pie = new PieChart()
                {
                    Width = 400,
                    Height = 200,
                    PieWidth = 190,
                    PieHeight = 190,
                    Margin = new Thickness(5, 5, 5, 5),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Data = collection,
                    PopupBrush = new SolidColorBrush(Colors.White),
                };
                pie.SetValue(Grid.ColumnProperty, counter);
                pie.SetValue(Grid.RowProperty, 1);
                Charts.Children.Add(pie);

                Label info = new Label();
                info.Content = $"Ранжування {step.Key}";
                info.VerticalAlignment = VerticalAlignment.Top;
                info.Margin = new Thickness(counter * 400 + 150, 0, 0, 0);
                info.Foreground = new SolidColorBrush(new Color() { A = 100, R = 93, G = 191, B = 56 });
                info.FontSize = 14;
                info.FontWeight = FontWeights.Bold;
                Base.Children.Add(info);

                counter++;
            }
        }
    }
}
