using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SimpleCriteriaComparer
{
    public static class Extensions
    {
        public static GradientStopCollection ToGradientStopCollection(this IEnumerable<GradientStop> col)
        {
            var collection = new GradientStopCollection();

            foreach (var item in col)
            {
                collection.Add(item);
            }
            return collection;
        }

        public static int GetMultipleArray(this int[] array)
        {
            var result = (-2) * array[0] + (-1) * array[1] + (0) * array[2] + (1) * array[3] + (2) * array[4];
            return result;
        }

        public static Dictionary<string, int[]> ToDictionary(this IOrderedEnumerable<KeyValuePair<string,int[]>> list)
        {
            var dictionary = new Dictionary<string, int[]>();
            foreach (var item in list)
            {
                dictionary.Add(item.Key, item.Value);
            }
            return dictionary;
        }
    }
}
