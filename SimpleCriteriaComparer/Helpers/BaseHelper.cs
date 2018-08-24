using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCriteriaComparer
{
    public class BaseHelper : IBaseHelper
    {
        public bool CheckAlternativesNamesForUniques(UIElementCollection collection)
        {
            var names = new List<string>();
            foreach (var item in collection)
            {
                if (names.Contains((item as TextBox).Text))
                {
                    MessageBox.Show($"Введена назва альтернативи {(item as TextBox).Text} зустрічається більше одного разу. Змініть назву однієї з повторюваних альтернатив.", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return true;
                }
                names.Add((item as TextBox).Text);
            }
            return false;
        }

        public void UpdateAlternatives(List<string> alternatives, UIElementCollection collection)
        {
            alternatives.Clear();

            for (int index = 0; index < collection.Count; index++)
            {
                var textBox = collection[index] as TextBox;

                alternatives.Add(textBox.Text);
            }
        }

        public void InitializeColors(List<string> alternatives)
        {
            var colorList = new List<Tuple<int, int, int>>();
            colorList.Add(new Tuple<int, int, int>(150, 0, 0));
            colorList.Add(new Tuple<int, int, int>(185, 0, 0));
            colorList.Add(new Tuple<int, int, int>(220, 0, 0));
            colorList.Add(new Tuple<int, int, int>(255, 0, 0));
            colorList.Add(new Tuple<int, int, int>(255, 30, 30));
            colorList.Add(new Tuple<int, int, int>(255, 60, 60));
            colorList.Add(new Tuple<int, int, int>(255, 90, 90));
            colorList.Add(new Tuple<int, int, int>(255, 120, 120));
            colorList.Add(new Tuple<int, int, int>(255, 150, 150));

            SoulData.ColorStorage.Clear();
            var index = default(int);

            alternatives.ForEach(x => {
                SoulData.ColorStorage.Add(alternatives[index], colorList[index]);
                index++;
            });
        }
    }
}
