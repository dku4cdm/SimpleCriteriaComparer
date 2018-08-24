using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCriteriaComparer
{
    public sealed class QuestionSource
    {
        private int Total { get; set; }

        public Dictionary<int, int[]> Source { get; set; }
        
        public QuestionSource(int alternatives)
        {
            Total = alternatives;
            Source = new Dictionary<int, int[]>();
            GenerateSource();
        }

        private void GenerateSource()
        {
            var key = default(int);

            for (int i = 0; i < Total; i++)
            {
                for (int j = i + 1; j < Total; j++)
                {
                    for (int k = j + 1; k < Total; k++)
                    {
                        Source.Add(key++, new int[3] { i, j, k });
                    }
                }
            }
        }

        public int[] GetIndexOfAlternatives(int step)
        {
            return Source[step - 1];
        }
    }
}
