using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SimpleCriteriaComparer
{
    public interface IDrawHelper
    {
        TextBox DrawTextBox();

        void UpdateNamesForAlternatives(UIElementCollection collection);

        Line DrawLine(int x1, int y1, int x2, int y2);

        Label DrawNumericLabel(string content, int marginLeft, int marginTop);

        void DrawNumericScalesForCircle(Grid grid);

        Line DrawLine(double x1, double y1, double x2, double y2);

        void HideCircleGrid(UIElementCollection collection);

        void ShowCircleGrid(UIElementCollection collection);

        void DrawCircleGrid(Canvas area);

        void DrawScalesForCircle(UIElementCollection collection);

        Rectangle DrawItemForMoving(double position, string name);

        Label DrawLabel(int id, string content);

        TextBlock DrawTextBlock(int id);
    }
}
