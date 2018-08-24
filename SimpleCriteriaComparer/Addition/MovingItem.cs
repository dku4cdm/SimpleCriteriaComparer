using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleCriteriaComparer
{
    public class MovingItem
    {
        internal bool drag = false;
        internal Point startPt;
        internal int width;
        internal int height;
        internal Point lastLocation;
        internal double CanvasLeft, CanvasTop;
    }
}
