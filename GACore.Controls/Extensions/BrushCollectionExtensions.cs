using System.Collections.Generic;
using System.Windows.Media;

namespace GACore.Controls.Extensions
{
    public static class BrushCollectionExtensions
    {
       
        public static BrushCollection GetBrushCollection<T>(this Dictionary<T, BrushCollection> dictionary, T key)
        {
            if (dictionary.ContainsKey(key)) return dictionary[key];

            return new BrushCollection(Properties.Resources.UI_Status_Unknown, Brushes.Crimson, Brushes.White);
        }
    }
}