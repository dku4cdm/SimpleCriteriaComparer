using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCriteriaComparer
{
    public static class SoulData
    {
        public static int[] SourceAlternative { get; set; }

        public static int[] SourceGradation { get; set; }

        public static int NumberOfAlternatives { get; set; }

        public static int TotalRankings { get; set; }

        public static int CurrentRanking { get; set; }

        public static int CurrentGradation { get; set; }

        public static List<string> Alternatives { get; set; }
        
        public static Dictionary<int, Dictionary<string, CirclePoint>> Storage { get; set; }

        public static Dictionary<string, Tuple<int, int, int>> ColorStorage { get; set; }

        public static void Initialize()
        {
            SourceAlternative = new int[6] { 4, 5, 6, 7, 8, 9 };
            SourceGradation = new int[6] { 5, 10, 20, 50, 100, 500 };
            NumberOfAlternatives = default(int);
            Alternatives = new List<string>();
            ColorStorage = new Dictionary<string, Tuple<int, int, int>>();
            Storage = new Dictionary<int, Dictionary<string, CirclePoint>>();
            CurrentRanking = default(int);
            CurrentGradation = 5;
            TotalRankings = default(int);
        }

        public static void FinalizeData()
        {
        }
    }
}
