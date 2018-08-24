using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SimpleCriteriaComparer
{
    public interface IBaseHelper
    {
        void UpdateAlternatives(List<string> alternatives, UIElementCollection collection);

        void InitializeColors(List<string> alternatives);

        bool CheckAlternativesNamesForUniques(UIElementCollection collection);
    }
}
